using CustomerOrders.Models.External.Order;

namespace CustomerOrders.Facades.Interfaces;

public interface IOrderService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerId">Идентификатор покупателя</param>
    /// <param name="limit">Кол-во заказов</param>
    /// <param name="offset">Смещение</param>
    /// <returns></returns>
    public Task<List<OrderDto>> GetOrderListByCustomerId(long customerId, long limit, long offset);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="regionId">Идентификатор региона</param>
    /// <param name="limit">Кол-во заказов</param>
    /// <param name="offset">Смещение</param>
    /// <returns></returns>
    public Task<List<OrderDto>> GetOrderListByRegionId(long regionId, long limit, long offset);
}