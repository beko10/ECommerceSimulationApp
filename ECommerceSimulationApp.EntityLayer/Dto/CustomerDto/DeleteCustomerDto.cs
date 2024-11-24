namespace ECommerceSimulationApp.EntityLayer.Dto.CustomerDto;

public class DeleteCustomerDto
{
    public string Id { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
