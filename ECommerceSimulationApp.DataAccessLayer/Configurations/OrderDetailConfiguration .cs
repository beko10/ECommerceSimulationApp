using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceSimulationApp.EntityLayer.Entity;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {

        // Ignore ID column
        builder.Ignore(od => od.Id);

        // Composite Key
        builder.HasKey(od => new { od.OrderID, od.ProductID });

        // Properties
        builder.Property(od => od.Quantity)
               .IsRequired();

        builder.Property(od => od.UnitPrice)
               .IsRequired();

        // Relationships
        builder.HasOne(od => od.Product)
               .WithMany(p => p.OrderDetails)
               .HasForeignKey(od => od.ProductID);

        builder.HasOne(od => od.Order)
               .WithMany(o => o.OrderDetails)
               .HasForeignKey(od => od.OrderID);

        // Seed Data
        builder.HasData(
            new OrderDetail { OrderID = "5ebc3c5b-faa3-4c3f-a440-5cf050a5c294", ProductID = "ec7f37f5-fa71-4c01-a69b-711f266e24fe", Quantity = 1, UnitPrice = 1200 },
            new OrderDetail { OrderID = "3cc0f5a0-2bfb-45f1-a76a-0be1af85f140", ProductID = "731e3c6a-db44-4674-9e24-0c81421b274a", Quantity = 3, UnitPrice = 20 }
        );
    }
}
