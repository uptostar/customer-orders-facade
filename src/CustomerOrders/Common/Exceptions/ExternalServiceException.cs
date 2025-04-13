using System.Net;

namespace CustomerOrders.Common.Exceptions;

public abstract class ExternalServiceException : Exception
{
    public string ServiceName { get; }
    public HttpStatusCode? StatusCode { get; }

    protected ExternalServiceException(string serviceName,
        string message, HttpStatusCode? statusCode = null,
        Exception innerException = null) : base(message, innerException)
    {
        ServiceName = serviceName;
        StatusCode = statusCode;
    }
}