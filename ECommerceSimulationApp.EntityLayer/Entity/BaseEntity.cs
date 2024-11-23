namespace ECommerceSimulationApp.EntityLayer.Entity;

public class BaseEntity
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
        CreatedDate = DateTime.Now;
        IsActive = true;
    }
}
