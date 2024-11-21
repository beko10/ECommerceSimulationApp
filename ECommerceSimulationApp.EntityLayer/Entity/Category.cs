namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Category : BaseEntity
{
    public string? CategoryName { get; set; }
    public string? Description { get; set; }

    //Navigation Property
    public ICollection<Product>? Products { get; set; } = [];

}
