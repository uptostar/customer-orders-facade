using CustomerOrders.Services.Order.Contracts;
using CustomerOrders.Services.Order.Contracts.Requests;
using CustomerOrders.Services.Order.Contracts.Responses;

namespace CustomerOrders.Services.Order.Client;

/// <summary>
/// Реализация клиента для взаимодействия с сервисом заказов.
/// Предоставляет методы для получения списка заказов по различным критериям.
/// </summary>
/// <remarks>
/// Этот класс реализует интерфейс <see cref="IOrderServiceClient"/>.
/// Он используется для выполнения HTTP-запросов к внешнему API заказов.
/// </remarks>
public class OrderServiceClient : IOrderServiceClient
{
    private readonly HttpClient _httpClient;
    
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="OrderServiceClient"/>.
    /// </summary>
    /// <param name="httpClient">
    /// Экземпляр <see cref="HttpClient"/>, который используется для выполнения HTTP-запросов к внешнему API заказов.
    /// Должен быть настроен с базовым адресом и необходимыми заголовками перед передачей в конструктор.
    /// </param>
    public OrderServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<OrderResponse>> GetOrderListByRegionIdAsync(GetOrderListByRegionIdRequest request)
    {
        var body = JsonContent.Create(request); 
        var response = await _httpClient.PostAsync($"/ordersByRegionId", body);

        response.EnsureSuccessStatusCode();
        
        var orders = await response.Content.ReadFromJsonAsync<IReadOnlyList<OrderResponse>>();

        return orders ?? [];
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<OrderResponse>> GetOrderListByCustomerIdAsync(GetOrderListByCustomerIdRequest request)
    {
        var body = JsonContent.Create(request); 
        var response = await _httpClient.PostAsync($"/ordersByRegionId", body);

        response.EnsureSuccessStatusCode();
        
        var orders = await response.Content.ReadFromJsonAsync<IReadOnlyList<OrderResponse>>();

        return orders ?? [];
    }
}