using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Models.External.Order;

namespace CustomerOrders.Facades;


public class OrderCustomerDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public List<OrderDto> Orders { get; set; }
}

public class OrderFacade : IOrderFacade
{
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;
    
    public OrderFacade(IOrderService orderService, ICustomerService customerService)
    {
        _orderService = orderService;
        _customerService = customerService;
    }
    
    public async Task<OrderCustomerDto> GetOrderListByCustomerId(long customerId, long limit, long offset)
    {
        var customer = _customerService.GetById(customerId);
        var orders = _orderService.GetOrderListByCustomerId(customerId, limit, offset);
        
        await Task.WhenAll(customer, orders);
        
        return new OrderCustomerDto
        {
            Id = customer.Result.Id,
            FullName = customer.Result.FullName,
            Orders = orders.Result
        };
    }

    public Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset)
    {
        throw new NotImplementedException();
    }
}