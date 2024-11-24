namespace ECommerceSimulationApp.EntityLayer.Entity;

public class BaseEntity
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }

    //saveChange methoduna ınterceptor yazıldı 
    //public BaseEntity()
    //{
    //    Id = Guid.NewGuid().ToString();
    //    CreatedDate = DateTime.Now;
    //    IsActive = true;
    //}
}
