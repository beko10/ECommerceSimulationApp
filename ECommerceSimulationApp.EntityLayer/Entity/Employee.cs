namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Employee : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public string FullName => $"{Name} {SurName}";
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<Order>? Orders { get; set; } = [];
}
