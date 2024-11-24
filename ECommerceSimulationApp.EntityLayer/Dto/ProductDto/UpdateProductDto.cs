namespace ECommerceSimulationApp.EntityLayer.Dto.ProductDto;

public class UpdateProductDto
{
    public string Id { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public double UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int UnitsInStock { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
}
