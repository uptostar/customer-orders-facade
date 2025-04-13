using System.Diagnostics;

namespace CustomerOrders.Middlewares;

/// <summary>
/// Промежуточный метод логирования времени обработки запроса
/// </summary>
public class RequestLatencyLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLatencyLoggingMiddleware> _logger;
    private readonly long _warningThresholdMs;
    
    public RequestLatencyLoggingMiddleware(RequestDelegate next, ILogger<RequestLatencyLoggingMiddleware> logger, long warningThresholdMs = 500)
    {
        _next = next;
        _logger = logger;
        _warningThresholdMs = warningThresholdMs;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await _next(context);
        }
        finally
        {
            stopwatch.Stop();
            LogRequestLatency(context, stopwatch.Elapsed);
        }
    }
    
    private void LogRequestLatency(HttpContext context, TimeSpan duration)
    {
        var logLevel = duration.TotalMilliseconds > _warningThresholdMs
            ? LogLevel.Warning
            : LogLevel.Information;

        _logger.Log(logLevel,
            "Request: {Method} {Path} completed in {DurationMs} ms | Status: {StatusCode}",
            context.Request.Method,
            context.Request.Path,
            duration.TotalMilliseconds,
            context.Response.StatusCode);
    }
}