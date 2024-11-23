namespace ECommerceSimulationApp.EntityLayer.Entity;

public class CardItem
{
    public string CardItemID { get; set; } = Guid.NewGuid().ToString();
    public string ProductID { get; set; } = string.Empty;
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
}
