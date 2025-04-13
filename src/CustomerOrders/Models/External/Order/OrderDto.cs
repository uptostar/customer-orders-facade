namespace CustomerOrders.Models.External.Order;

public class OrderDto
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public Region Region { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public long TotalCount { get; set; }
}

/// <summary>
/// 
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// 
    /// </summary>
    Undefined,
    /// <summary>
    /// 
    /// </summary>
    New,
    /// <summary>
    /// 
    /// </summary>
    Cancelled,
    /// <summary>
    /// 
    /// </summary>
    Delivered
}