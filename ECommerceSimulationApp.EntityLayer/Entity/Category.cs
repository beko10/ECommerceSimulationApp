namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Category : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    //Navigation Property
    public ICollection<Product>? Products { get; set; } = [];

}
