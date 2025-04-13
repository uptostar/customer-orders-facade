using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Models.External.Customer;

namespace CustomerOrders.Services;


/// <summary>
///  
/// </summary>
public class CustomerService : ICustomerService
{
    private const string ServiceUrl = "http://localhost:5002";
    private readonly HttpClient _client;
    
    public CustomerService()
    {
        _client = new HttpClient { BaseAddress = new Uri(ServiceUrl) };
    }

    /// <inheritdoc />
    public async Task<List<CustomerDto>> GetAll()
    {
        var response = await _client.GetAsync("/customers");

        if (!response.IsSuccessStatusCode)
        {
            //TODO: Добавить свои ошибки
            return null;
        }
            
        var customers = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
        
        return customers ?? [];
    }

    /// <inheritdoc />
    public async Task<CustomerDto> GetById(long id)
    {
        var response = await _client.GetAsync($"/customers/{id}");

        if (!response.IsSuccessStatusCode)
        {
            //TODO: Добавить свои ошибки
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApplicationException($"Failed to get customer. Status code: {response.StatusCode}, Message: {errorContent}");
        }
        
        var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();
        
        if (customer == null)
        {
            throw new ApplicationException("Customer data is null or invalid.");
        }
        
        return customer;
    }

    /// <inheritdoc />
    public async Task<List<CustomerDto>> GetCustomerListByRegionId(long regionId)
    {
        var response = await _client.GetAsync($"/customersByRegionId/{regionId}");

        if (!response.IsSuccessStatusCode)
        {
            //TODO: Добавить свои ошибки
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApplicationException($"Failed to get customers. Status code: {response.StatusCode}, Message: {errorContent}");
        }
        
        var customers = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
        
        return customers ?? [];
    }
}