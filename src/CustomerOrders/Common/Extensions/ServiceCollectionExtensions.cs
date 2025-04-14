using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades;
using CustomerOrders.Services.Customer.Client;
using CustomerOrders.Services.Customer.Contracts;
using CustomerOrders.Services.Customer.Models.Config;
using CustomerOrders.Services.Order.Client;
using CustomerOrders.Services.Order.Contracts;
using CustomerOrders.Services.Order.Models.Config;
using Microsoft.Extensions.Options;

namespace CustomerOrders.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CustomerServiceConfig>(configuration.GetSection("Services:Customer"));
        services.Configure<OrderServiceConfig>(configuration.GetSection("Services:Order"));
        
        services.AddHttpClient<IOrderService, OrderService>((provider, client) =>
        {
            var config = provider.GetRequiredService<IOptions<OrderServiceConfig>>().Value;
            
            client.BaseAddress = config.GetUri();
            client.Timeout = TimeSpan.FromSeconds(config.Timeout);
        });
        
        services.AddHttpClient<ICustomerService, CustomerService>((provider, client) =>
        {
            var config = provider.GetRequiredService<IOptions<CustomerServiceConfig>>().Value;
            
            client.BaseAddress = config.GetUri();
            client.Timeout = TimeSpan.FromSeconds(config.Timeout);
        });

        return services;
    }
    
    public static IServiceCollection AddInternalServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderFacade, OrderFacade>();

        return services;
    }
}