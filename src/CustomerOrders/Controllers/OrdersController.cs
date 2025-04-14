using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrders.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="orderFacade"></param>
[ApiController]
[Route("api/[controller]")]
public class OrdersController(IOrderFacade orderFacade) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="regionId"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    [HttpGet("/region/{regionId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public string GetOrderListByRegionId(
        long regionId, [FromQuery] long offset = 0, [FromQuery] long limit = 15)
    {
        orderFacade.GetOrderListByRegionId(regionId, limit, offset);
        
        return $"Hello World! RegionID: {regionId}, take: {limit}, skip: {offset}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    [HttpGet("/customer/{customerId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<OrderCustomerDto> GetOrderListByCustomerId(
        long customerId, [FromQuery] long offset = 0, [FromQuery] long limit = 15) =>
        await orderFacade.GetOrderListByCustomerId(customerId, limit, offset);
}