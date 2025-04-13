using System.Net;

namespace CustomerOrders.Common.Exceptions;

public class ExternalServiceApiException : ExternalServiceException
{
    public object ResponseData { get; }
    
    public ExternalServiceApiException(string serviceName, 
        string errorMessage, HttpStatusCode statusCode,
        object responseData = null, Exception innerException = null)
        : base(serviceName, errorMessage, statusCode, innerException)
    {
        ResponseData = responseData;
    }
}