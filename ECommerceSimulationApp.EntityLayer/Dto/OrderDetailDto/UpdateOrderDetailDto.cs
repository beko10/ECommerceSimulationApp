namespace ECommerceSimulationApp.EntityLayer.Dto.OrderDetailDto;

public class UpdateOrderDetailDto
{
    public string Id { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
}
