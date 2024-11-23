namespace ECommerceSimulationApp.EntityLayer.Entity;

public class OrderDetail : BaseEntity
{
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public Product? Product { get; set; }
    public Order? Order { get; set; }
    public  string ProductID { get; set; } = string.Empty;  
    public string OrderID { get; set; } = string.Empty;
}
