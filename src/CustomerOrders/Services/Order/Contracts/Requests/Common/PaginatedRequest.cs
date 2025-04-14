using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Services.Order.Contracts.Requests.Common;

public abstract class PaginatedRequest
{
    [Range(1, 1000)]
    public long Limit { get; set; }
    
    [Range(1, int.MaxValue)]
    public int Offset { get; set; }
}