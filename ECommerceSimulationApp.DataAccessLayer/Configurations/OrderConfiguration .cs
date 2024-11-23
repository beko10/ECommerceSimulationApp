using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceSimulationApp.EntityLayer.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Primary Key
        builder.HasKey(o => o.Id);

        // Properties
        builder.Property(o => o.OrderDate)
               .IsRequired();

        builder.Property(o => o.ShipAddress)
               .HasMaxLength(200);

        builder.Property(o => o.ShipCity)
               .HasMaxLength(100);

        builder.Property(o => o.ShipCountry)
               .HasMaxLength(100);

        // Relationships
        builder.HasOne(o => o.Customer)
               .WithMany(c => c.Orders)
               .HasForeignKey(o => o.CustomerID);

        builder.HasOne(o => o.Employee)
               .WithMany(e => e.Orders)
               .HasForeignKey(o => o.EmployeeID);

        builder.HasMany(o => o.OrderDetails)
               .WithOne(od => od.Order)
               .HasForeignKey(od => od.OrderID);

        // Seed Data
        builder.HasData(
            new Order
            {
                Id = "5ebc3c5b-faa3-4c3f-a440-5cf050a5c294",
                OrderDate = new DateOnly(2024, 1, 15),
                ShipAddress = "123 Main St",
                ShipCity = "New York",
                ShipCountry = "USA",
                CustomerID = "20bf8e13-9c70-4c34-968b-f6209174d83d",
                EmployeeID = "0ad68950-0cfe-4760-9fb0-23dd47a26842"
            },
            new Order
            {
                Id = "3cc0f5a0-2bfb-45f1-a76a-0be1af85f140",
                OrderDate = new DateOnly(2024, 2, 10),
                ShipAddress = "456 Market St",
                ShipCity = "London",
                ShipCountry = "UK",
                CustomerID = "5a9cf13b-b9a8-4758-b2a8-cc6b871d1009",
                EmployeeID = "e918542d-0292-434b-93f9-af4607c4b181"
            }
        );
    }
}
