using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceSimulationApp.EntityLayer.Entity;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.ProductName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(p => p.UnitPrice)
               .IsRequired();

        builder.Property(p => p.UnitsInStock)
               .IsRequired();

        // Relationships
        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryID);

        builder.HasOne(p => p.Supplier)
               .WithMany(s => s.Products)
               .HasForeignKey(p => p.SupplierID);

        builder.HasMany(p => p.OrderDetails)
               .WithOne(od => od.Product)
               .HasForeignKey(od => od.ProductID);

        // Seed Data
        builder.HasData(
            new Product
            {
                Id = "ec7f37f5-fa71-4c01-a69b-711f266e24fe",
                ProductName = "Laptop",
                UnitPrice = 1200,
                Discontinued = false,
                UnitsInStock = 50,
                CategoryID = "ed36652f-b238-4cc9-a646-e758ccf8e19f",
                SupplierID = "a5d4e59c-1899-4941-8657-bc1fb30f518b"
            },
            new Product
            {
                Id = "731e3c6a-db44-4674-9e24-0c81421b274a",
                ProductName = "T-Shirt",
                UnitPrice = 20,
                Discontinued = false,
                UnitsInStock = 200,
                CategoryID = "cc7708f9-3b6f-454e-9f5f-5c721de8ef51",
                SupplierID = "ce604596-7139-4412-b2d2-35bd5b1a161d"
            }
        );
    }
}
