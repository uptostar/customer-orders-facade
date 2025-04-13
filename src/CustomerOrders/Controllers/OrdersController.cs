using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades;
using CustomerOrders.Models.External.Order;
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
    private readonly IOrderFacade _orderFacade = orderFacade;

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
    public IActionResult GetOrderListByRegionId(long regionId, [FromQuery] long offset = 0, [FromQuery] long limit = 15)
    {
        _orderFacade.GetOrderListByRegionId(regionId, limit, offset);
        
        return Ok($"Hello World! RegionID: {regionId}, take: {limit}, skip: {offset}");
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
    public async Task<OrderCustomerDto> GetOrderListByCustomerId(long customerId,
        [FromQuery] long offset = 0, [FromQuery] long limit = 15) =>
        await _orderFacade.GetOrderListByCustomerId(customerId, limit, offset);
}