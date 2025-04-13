using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Models.External.Order;

namespace CustomerOrders.Facades;

public class OrderFacade : IOrderFacade
{
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;
    
    public OrderFacade(IOrderService orderService, ICustomerService customerService)
    {
        _orderService = orderService;
        _customerService = customerService;
    }
    
    public async Task<List<OrderDto>> GetOrderListByCustomerId(long customerId, long limit, long offset)
    {
        var customers = _customerService.GetCustomerListByRegionId(customerId);
        var orders = _orderService.GetOrderListByCustomerId(customerId, limit, offset);
        
        await Task.WhenAll(customers, orders);
        
        if (customers.Result is null)
        {
            throw new Exception();
        }

        if (orders.Result is null)
        {
            throw new Exception();
        }
        
        
        
        return [];
    }

    public Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset)
    {
        throw new NotImplementedException();
    }
}