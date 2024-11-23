using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceSimulationApp.EntityLayer.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        // Properties
        builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(e => e.SurName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(e => e.Phone)
               .HasMaxLength(15);

        // Relationships
        builder.HasMany(e => e.Orders)
               .WithOne(o => o.Employee)
               .HasForeignKey(o => o.EmployeeID);

        // Seed Data
        builder.HasData(
            new Employee { Id = "0ad68950-0cfe-4760-9fb0-23dd47a26842", Name = "Alice", SurName = "Johnson", Country = "USA", City = "Seattle", Phone = "1122334455" },
            new Employee { Id = "e918542d-0292-434b-93f9-af4607c4b181", Name = "Bob", SurName = "Williams", Country = "Canada", City = "Toronto", Phone = "2233445566" }
        );
    }
}
