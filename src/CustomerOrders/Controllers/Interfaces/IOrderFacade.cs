using CustomerOrders.Models.External.Order;

namespace CustomerOrders.Controllers.Interfaces;

public interface IOrderFacade
{
    public Task<List<OrderDto>> GetOrderListByCustomerId(long customerId, long limit, long offset);
    
    public Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset);
}