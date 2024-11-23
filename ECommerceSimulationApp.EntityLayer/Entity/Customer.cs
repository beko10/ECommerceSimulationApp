namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Customer : BaseEntity
{
    public string CustomerName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<Order>? Orders { get; set; } = [];
}
