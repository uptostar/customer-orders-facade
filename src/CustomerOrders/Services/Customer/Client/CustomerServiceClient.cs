using CustomerOrders.Services.Customer.Client.Exceptions;
using CustomerOrders.Services.Customer.Contracts;
using CustomerOrders.Services.Customer.Contracts.Requests;
using CustomerOrders.Services.Customer.Contracts.Responses;

namespace CustomerOrders.Services.Customer.Client;

/// <summary>
/// Реализация клиента для взаимодействия с сервисом клиентов.
/// </summary>
/// <remarks>
/// Этот класс реализует интерфейс <see cref="ICustomerServiceClient"/> и предоставляет методы
/// для получения информации о клиентах через HTTP-запросы.
/// Класс использует <see cref="HttpClient"/> для выполнения запросов к внешнему API.
/// </remarks>
public class CustomerServiceClient : ICustomerServiceClient
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CustomerServiceClient"/>.
    /// </summary>
    /// <param name="httpClient">
    /// Экземпляр <see cref="HttpClient"/>, который используется для выполнения HTTP-запросов к внешнему API.
    /// Должен быть настроен с базовым адресом и необходимыми заголовками перед передачей в конструктор.
    /// </param>
    /// <remarks>
    /// Этот конструктор внедряет зависимость <see cref="HttpClient"/> через Dependency Injection (DI).
    /// </remarks>
    public CustomerServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<CustomerResponse> GetCustomerByIdAsync(GetCustomerByIdRequest request)
    {
        var response = await _httpClient.GetAsync($"/customers/{request.Id}");

        response.EnsureSuccessStatusCode();
        
        var customer = await response.Content.ReadFromJsonAsync<CustomerResponse>();
        
        if (customer == null)
        {
            throw new CustomerNotFoundException(request.Id);
        }
        
        return customer;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<CustomerResponse>> GetCustomerListAsync()
    {
        var response = await _httpClient.GetAsync("/customers");
        
        response.EnsureSuccessStatusCode();
        
        var customers = await response.Content.ReadFromJsonAsync<IReadOnlyList<CustomerResponse>>();
        
        return customers ?? [];
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<CustomerResponse>> GetCustomerListByRegionIdAsync(GetCustomerListByRegionIdRequest request)
    {
        var response = await _httpClient.GetAsync($"/customersByRegionId/{request.Id}");

        response.EnsureSuccessStatusCode();
        
        var customers = await response.Content.ReadFromJsonAsync<IReadOnlyList<CustomerResponse>>();
        
        return customers ?? [];
    }
}