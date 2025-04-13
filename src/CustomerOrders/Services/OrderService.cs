using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Models.External.Order;

namespace CustomerOrders.Services;

public class OrderService : IOrderService
{
    private const string ServiceUrl = "http://localhost:5002";
    private readonly HttpClient _client;

    public OrderService()
    {
        _client = new HttpClient { BaseAddress = new Uri(ServiceUrl) };
    }

    /// <inheritdoc />
    public async Task<List<OrderDto>> GetOrderListByCustomerId(long customerId, long limit, long offset)
    {
        var body = JsonContent.Create(new { customerId, limit, offset }); 
        var response = await _client.PostAsync($"/ordersByCustomerId", body);
        
        if (!response.IsSuccessStatusCode)
        {
            //TODO: Добавить свои ошибки
            throw new HttpRequestException($"Failed to get orders by customer id: {response.ReasonPhrase}");
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
            //TODO: Добавить свои ошибки
            throw new HttpRequestException($"Failed to get orders by region id: {response.ReasonPhrase}");
        }
        
        var orders = await response.Content.ReadFromJsonAsync<List<OrderDto>>();

        return orders ?? [];
    }
}