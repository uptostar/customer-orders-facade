using System.Net;

namespace CustomerOrders.Common.Exceptions;

public class ExternalServiceTimeoutException : ExternalServiceException
{
    public TimeSpan Timeout { get; }
    
    public ExternalServiceTimeoutException(string serviceName, TimeSpan timeout,
        string message, HttpStatusCode? statusCode = null, Exception innerException = null) 
        : base(serviceName, message, statusCode, innerException)
    {
        Timeout = timeout;
    }
}