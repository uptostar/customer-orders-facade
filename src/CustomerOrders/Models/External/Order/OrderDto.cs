using System.Text.Json.Serialization;

namespace CustomerOrders.Models.External.Order;

public class OrderDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("customerId")]
    public long CustomerId { get; set; }
    [JsonPropertyName("region")]
    public Region Region { get; set; }
    [JsonPropertyName("orderStatus")]
    public OrderStatus OrderStatus { get; set; }
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("totalCount")]
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