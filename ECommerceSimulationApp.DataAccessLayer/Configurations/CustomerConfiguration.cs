using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceSimulationApp.EntityLayer.Entity;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Primary Key
        builder.HasKey(c => c.Id);

        // Properties
        builder.Property(c => c.CustomerName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Phone)
               .HasMaxLength(15);

        // Relationships
        builder.HasMany(c => c.Orders)
               .WithOne(o => o.Customer)
               .HasForeignKey(o => o.CustomerID);

        // Seed Data
        builder.HasData(
            new Customer { Id = "20bf8e13-9c70-4c34-968b-f6209174d83d", CustomerName = "John Doe", Country = "USA", City = "New York", Phone = "1234567890" },
            new Customer { Id = "5a9cf13b-b9a8-4758-b2a8-cc6b871d1009", CustomerName = "Jane Smith", Country = "UK", City = "London", Phone = "9876543210" }
        );
    }
}
