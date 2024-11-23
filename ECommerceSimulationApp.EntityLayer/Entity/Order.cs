namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Order : BaseEntity
{
    public DateOnly OrderDate { get; set; }
    public string ShipAddress { get; set; } = string.Empty;
    public string  ShipCity { get; set; } = string.Empty;
    public string ShipCountry { get; set; } = string.Empty;
    public Employee? Employee { get; set; }
    public string EmployeeID { get; set; } = string.Empty;
    public Customer? Customer { get; set; }
    public string CustomerID { get; set; } = string.Empty;
    public ICollection<OrderDetail>? OrderDetails { get; set; } = [];
}
