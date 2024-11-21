namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Customer : BaseEntity
{
    public string? CustomerName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public ICollection<Order>? Orders { get; set; } = [];
}
