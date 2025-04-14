using CustomerOrders.Facades;

namespace CustomerOrders.Controllers.Interfaces;

public interface IOrderFacade
{
    public Task<OrderCustomerDto> GetOrderListByCustomerId(long customerId, long limit, long offset);
    
    public Task<List<int>> GetOrderListByRegionId(long regionId, long limit, long offset);
}