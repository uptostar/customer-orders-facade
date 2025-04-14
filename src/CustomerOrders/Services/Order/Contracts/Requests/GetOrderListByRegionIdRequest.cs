using System.ComponentModel.DataAnnotations;
using CustomerOrders.Services.Order.Contracts.Requests.Common;

namespace CustomerOrders.Services.Order.Contracts.Requests;

public class GetOrderListByRegionIdRequest : PaginatedRequest
{
    [Required]
    public long RegionId { get; set; }
}