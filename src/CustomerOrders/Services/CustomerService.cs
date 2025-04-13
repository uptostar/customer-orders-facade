using System.Net;
using System.Text.Json;
using CustomerOrders.Common.Exceptions;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Models.External.Customer;

namespace CustomerOrders.Services;


/// <summary>
///  
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly string _serviceName;
    private readonly HttpClient _client;
    
    public CustomerService(HttpClient client)
    {
        _client = client;
        _serviceName = "CustomerService";
    }

    /// <inheritdoc />
    public async Task<List<CustomerDto>> GetAll()
    {
        var response = await _client.GetAsync("/customers");

        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorResponse(response);
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
            await HandleErrorResponse(response);
        }
        
        var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();
        
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID: {id} not found.");
        }
        
        return customer;
    }

    /// <inheritdoc />
    public async Task<List<CustomerDto>> GetCustomerListByRegionId(long regionId)
    {
        var response = await _client.GetAsync($"/customersByRegionId/{regionId}");

        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorResponse(response);
        }
        
        var customers = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
        
        return customers ?? [];
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