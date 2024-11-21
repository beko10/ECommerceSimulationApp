namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Order : BaseEntity
{
    public DateOnly OrderDate { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipCountry { get; set; }
    public Employee? Employee { get; set; }
    public string? EmployeeID { get; set; }
    public Customer? Customer { get; set; }
    public string? CustomerID { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; } = [];
}
