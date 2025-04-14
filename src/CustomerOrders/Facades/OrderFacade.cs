using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Services.Customer.Contracts;
using CustomerOrders.Services.Customer.Contracts.Requests;
using CustomerOrders.Services.Order.Contracts;

namespace CustomerOrders.Facades;


public class OrderCustomerDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public List<int> Orders { get; set; }
}

public class OrderFacade : IOrderFacade
{
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;
    
    public OrderFacade(ICustomerService customerService, IOrderService orderService)
    {
        _customerService = customerService;
        _orderService = orderService;
    }
    
    public async Task<OrderCustomerDto> GetOrderListByCustomerId(long customerId, long limit, long offset)
    {
        var customer = await _customerService.GetCustomerByIdAsync(new GetCustomerByIdRequest { Id = customerId });
        // var orders = _orderService.GetOrderListByCustomerId(customerId, limit, offset);
        
        // await Task.WhenAll(customer, orders);
        
        return new OrderCustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Orders = []
        };
    }

    public Task<List<int>> GetOrderListByRegionId(long regionId, long limit, long offset)
    {
        throw new NotImplementedException();
    }
}