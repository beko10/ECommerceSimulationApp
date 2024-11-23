using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceSimulationApp.EntityLayer.Entity;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        // Primary Key
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.CompanyName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(s => s.ContactTitle)
               .HasMaxLength(100);

        builder.Property(s => s.Phone)
               .HasMaxLength(15);

        // Relationships
        builder.HasMany(s => s.Products)
               .WithOne(p => p.Supplier)
               .HasForeignKey(p => p.SupplierID);

        // Seed Data
        builder.HasData(
            new Supplier { Id = "a5d4e59c-1899-4941-8657-bc1fb30f518b", CompanyName = "TechSupplier Inc.", ContactTitle = "Manager", Country = "USA", City = "San Francisco", Phone = "3344556677" },
            new Supplier { Id = "ce604596-7139-4412-b2d2-35bd5b1a161d", CompanyName = "Fashion World", ContactTitle = "Owner", Country = "Italy", City = "Milan", Phone = "4455667788" }
        );
    }
}
