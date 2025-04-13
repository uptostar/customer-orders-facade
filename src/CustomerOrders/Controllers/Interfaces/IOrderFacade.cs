using CustomerOrders.Facades;
using CustomerOrders.Models.External.Order;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrders.Controllers.Interfaces;

public interface IOrderFacade
{
    public Task<OrderCustomerDto> GetOrderListByCustomerId(long customerId, long limit, long offset);
    
    public Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset);
}