namespace ECommerceSimulationApp.EntityLayer.Dto.EmployeeDto;

public class UpdateEmployeeDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public string FullName => $"{Name} {SurName}";
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
