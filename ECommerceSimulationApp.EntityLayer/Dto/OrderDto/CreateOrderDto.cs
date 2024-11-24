namespace ECommerceSimulationApp.EntityLayer.Dto.OrderDto;

public class CreateOrderDto
{
    public DateOnly OrderDate { get; set; }
    public string ShipAddress { get; set; } = string.Empty;
    public string ShipCity { get; set; } = string.Empty;
    public string ShipCountry { get; set; } = string.Empty;
}
