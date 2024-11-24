namespace ECommerceSimulationApp.EntityLayer.Dto.ProductDto;

public class DeleteProductDto
{
    public string Id { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public double UnitPrice { get; set; }
    public bool Discontinued { get; set; }
    public int UnitsInStock { get; set; }
    public string CategoryID { get; set; } = string.Empty;
    public string SupplierID { get; set; } = string.Empty;
}
