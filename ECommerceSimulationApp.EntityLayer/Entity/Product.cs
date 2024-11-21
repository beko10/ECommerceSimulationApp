namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Product : BaseEntity
{
    public string? ProductName { get; set; }
    public double UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int UnitsInStock { get; set; }
    public string? CategoryID { get; set; }
    public string? SupplierID { get; set; }

    //Navigation Property
    public Category? Category { get; set; }
    public Supplier? Supplier { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; } = [];
}
