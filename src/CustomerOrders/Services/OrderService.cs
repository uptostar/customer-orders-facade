using System.Net;
using System.Text.Json;
using CustomerOrders.Common.Exceptions;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Models.External.Order;

namespace CustomerOrders.Services;

public class OrderService : IOrderService
{
    private readonly string _serviceName;
    private readonly HttpClient _client;

    public OrderService(HttpClient client)
    {
        _client = client;
        _serviceName = "OrderService";
    }

    /// <inheritdoc />
    public async Task<List<OrderDto>> GetOrderListByCustomerId(long customerId, long limit, long offset)
    {
        var body = JsonContent.Create(new { customerId, limit, offset }); 
        var response = await _client.PostAsync($"/ordersByCustomerId", body);
        
        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorResponse(response);
        }
        
        var orders = await response.Content.ReadFromJsonAsync<List<OrderDto>>();

        return orders ?? [];
    }

    /// <inheritdoc />
    public async Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset)
    {
        var body = JsonContent.Create(new { regionId, limit, offset }); 
        var response = await _client.PostAsync($"/ordersByRegionId", body);

        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorResponse(response);
        }
        
        var orders = await response.Content.ReadFromJsonAsync<List<OrderDto>>();

        return orders ?? [];
    }
    
    private async Task HandleErrorResponse(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();

        object errorData = null;
        try
        {
            errorData = JsonSerializer.Deserialize<JsonElement>(content);
        }
        catch { }

        throw response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new ExternalServiceApiException(
                _serviceName, "Invalid request", response.StatusCode, errorData),
                
            HttpStatusCode.Unauthorized => new ExternalServiceApiException(
                _serviceName, "Authentication failed", response.StatusCode),
                
            HttpStatusCode.ServiceUnavailable => new ExternalServiceUnavailableException(
                _serviceName, "Service temporarily unavailable", response.StatusCode,
                response.Headers.RetryAfter?.Delta),
                
            _ => new ExternalServiceApiException(
                _serviceName, $"Unexpected error: {response.StatusCode}", 
                response.StatusCode, errorData)
        };
    }
}