namespace ECommerceSimulationApp.EntityLayer.Entity;

public class Card
{
    public string CardID { get; set; } = Guid.NewGuid().ToString();
    public List<CardItem> CardItems { get; set; } = new List<CardItem>();
}
