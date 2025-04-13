using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Services;

namespace CustomerOrders.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddHttpClient<IOrderService, OrderService>("OrderService", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5003");
            client.Timeout = TimeSpan.FromSeconds(30);
        });
        
        services.AddHttpClient<ICustomerService, CustomerService>("CustomerService", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5002");
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        return services;
    }
    
    public static IServiceCollection AddInternalServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderFacade, OrderFacade>();

        return services;
    }
}