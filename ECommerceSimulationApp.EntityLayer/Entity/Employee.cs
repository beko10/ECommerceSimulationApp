namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Employee : BaseEntity
{
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public string? FullName => $"{Name} {SurName}";
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public ICollection<Order>? Orders { get; set; } = [];
}
