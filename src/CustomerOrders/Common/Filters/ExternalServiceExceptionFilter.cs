using System.Net;
using CustomerOrders.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerOrders.Common.Filters;

public class ExternalServiceExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExternalServiceException ex)
        {
            var problem = new ProblemDetails
            {
                Title = "External Service Error",
                Detail = ex.Message,
                Status = (int)(ex.StatusCode ?? HttpStatusCode.BadGateway),
                Extensions =
                {
                    ["service"] = ex.ServiceName,
                    ["timestamp"] = DateTime.UtcNow
                }
            };

            if (ex is ExternalServiceApiException { ResponseData: not null } apiEx)
            {
                problem.Extensions["response"] = apiEx.ResponseData;
            }

            context.Result = new ObjectResult(problem) 
            { 
                StatusCode = problem.Status 
            };
            context.ExceptionHandled = true;
        }
    }
}