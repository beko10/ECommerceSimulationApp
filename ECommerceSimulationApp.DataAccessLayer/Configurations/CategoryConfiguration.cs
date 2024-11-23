using ECommerceSimulationApp.EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSimulationApp.DataAccessLayer.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //Primary Key 
        builder.HasKey(c => c.Id);

        //property configuration 
        builder.Property(c => c.CategoryName)
               .IsRequired()
               .HasMaxLength(25);
        

        builder.Property(c => c.Description)
               .IsRequired()
               .HasMaxLength(25);

        //Relationships Configuration
        builder.HasMany(c => c.Products)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.CategoryID);


        //Seed Data 
        builder.HasData(
                new Category { Id = "ed36652f-b238-4cc9-a646-e758ccf8e19f", CategoryName = "Electronics", Description = "Electronic Items" },
                new Category { Id = "cc7708f9-3b6f-454e-9f5f-5c721de8ef51", CategoryName = "Books", Description = "Books and Stationery" });
    }
}




/*
Not: IEntityTypeConfiguration arayüzü ile migration sırasında entitye özgü konfigürasyon ayarları yapılır 
 
 */