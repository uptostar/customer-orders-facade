namespace CustomerOrders.Middlewares;

/// <summary>
/// Промежуточный метод логирования времени обработки запроса
/// </summary>
public class RequestLatencyLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLatencyLoggingMiddleware> _logger;
    
    public RequestLatencyLoggingMiddleware(RequestDelegate next, ILogger<RequestLatencyLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.UtcNow;

        await _next(context);

        var endTime = DateTime.UtcNow;
        var duration = endTime - startTime;

        _logger.LogInformation(
            "Request: {Method} {Path} {Query} completed in {Duration} ms",
            context.Request.Method,
            context.Request.Path,
            context.Request.Query,
            duration.TotalMilliseconds);
    }
}