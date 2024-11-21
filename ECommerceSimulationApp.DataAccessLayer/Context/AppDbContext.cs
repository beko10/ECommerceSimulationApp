using ECommerceSimulationApp.EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimulationApp.DataAccessLayer.Context;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //OrderDetail Tbl için id iptal edildi 
        modelBuilder.Entity<OrderDetail>().Ignore(or => or.Id);

        //OrderDetail Tbl için OrderId ve ProductId sutunları kullanılarak Composite Key yapılandırılması yapıldı
        modelBuilder.Entity<OrderDetail>().HasKey(or => new
        {
            or.OrderID,
            or.ProductID,
        });
    }
}
