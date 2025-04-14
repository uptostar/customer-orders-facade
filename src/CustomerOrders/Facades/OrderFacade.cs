using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Models.External.Order;
using CustomerOrders.Services.Customer.Contracts;
using CustomerOrders.Services.Customer.Contracts.Requests;
using CustomerOrders.Services.Order.Contracts;

namespace CustomerOrders.Facades;


public class OrderCustomerDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public List<OrderDto> Orders { get; set; }
}

public class OrderFacade : IOrderFacade
{
    private readonly ICustomerServiceClient _customerServiceClient;
    private readonly IOrderServiceClient _orderServiceClient;
    
    public OrderFacade(ICustomerServiceClient customerServiceClient, IOrderServiceClient orderServiceClient)
    {
        _customerServiceClient = customerServiceClient;
        _orderServiceClient = orderServiceClient;
    }
    
    public async Task<OrderCustomerDto> GetOrderListByCustomerId(long customerId, long limit, long offset)
    {
        var customer = await _customerServiceClient.GetCustomerByIdAsync(new GetCustomerByIdRequest { Id = customerId });
        // var orders = _orderService.GetOrderListByCustomerId(customerId, limit, offset);
        
        // await Task.WhenAll(customer, orders);
        
        return new OrderCustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Orders = []
        };
    }

    public Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset)
    {
        throw new NotImplementedException();
    }
}