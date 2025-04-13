namespace CustomerOrders.Models.External.Customer;

public class CustomerDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public Region Region { get; set; }
    public DateTime CreatedAt { get; set; }
};