using System.Net;

namespace CustomerOrders.Common.Exceptions;

public class ExternalServiceUnavailableException : ExternalServiceException
{
    public TimeSpan? RetryAfter { get; }
    
    public ExternalServiceUnavailableException(string serviceName, 
        string errorDetails, HttpStatusCode? statusCode = null,
        TimeSpan? retryAfter = null, Exception innerException = null)
        : base(serviceName, $"Service unavailable: {errorDetails}", 
            statusCode, innerException)
    {
        RetryAfter = retryAfter;
    }
}