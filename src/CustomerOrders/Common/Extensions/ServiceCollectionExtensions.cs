using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Services;

namespace CustomerOrders.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
    
    public static IServiceCollection AddInternalServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderFacade, OrderFacade>();

        return services;
    }
}