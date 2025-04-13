using CustomerOrders.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerOrders.Common.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _env;

    public GlobalExceptionFilter(IHostEnvironment env)
    {
        _env = env;
    }
    
    public void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "Internal Server Error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = _env.IsDevelopment() ? context.Exception.ToString() : null,
            Instance = context.HttpContext.Request.Path,
        };

        switch (context.Exception)
        {
            case NotFoundException notFoundEx:
                problemDetails.Title = notFoundEx.Message;
                problemDetails.Status = StatusCodes.Status404NotFound;
                break;
        }

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };

        context.ExceptionHandled = true;
    }
}