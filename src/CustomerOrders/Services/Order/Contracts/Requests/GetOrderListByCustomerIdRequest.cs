using System.ComponentModel.DataAnnotations;
using CustomerOrders.Services.Order.Contracts.Requests.Common;

namespace CustomerOrders.Services.Order.Contracts.Requests;

public class GetOrderListByCustomerIdRequest : PaginatedRequest
{
    [Required]
    public long CustomerId { get; set; }
}