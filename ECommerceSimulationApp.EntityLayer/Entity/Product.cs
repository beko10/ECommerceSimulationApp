namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Product : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public double UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int UnitsInStock { get; set; }
    public string CategoryID { get; set; } = string.Empty;
    public string SupplierID { get; set; } = string.Empty;

    //Navigation Property
    public Category? Category { get; set; }
    public Supplier? Supplier { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; } = [];
}
