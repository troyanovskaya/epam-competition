using System;
using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasIndex(c => c.Name)
                .IsUnique();
            
            builder.Property(c => c.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories);

            builder.HasData
            (
                new Category
                {
                    Id = new Guid("41f9836e-c0cb-43a6-a842-22e6f5a60f1d"),
                    Name = "Farm boxes"
                },
                new Category
                {
                    Id = new Guid("7cd2e12d-c85d-4d97-9c18-808dff6151f4"),
                    Name = "Produce"
                },
                new Category
                {
                    Id = new Guid("4374b672-d0b1-4f31-b512-408400ce6105"),
                    Name = "Meat & Seafood"
                },
                new Category
                {
                    Id = new Guid("c11d3cf5-6847-4281-9950-52b03f3811fa"),
                    Name = "Dairy & Eggs"
                },
                new Category
                {
                    Id = new Guid("40ff4e36-58e3-408a-b563-aa51c7db51a2"),
                    Name = "Bakery"
                },
                new Category
                {
                    Id = new Guid("2766062f-f160-49aa-bd48-c62ac0b2b0da"),
                    Name = "Pantry"
                },
                new Category
                {
                    Id = new Guid("e9a69e36-98e3-4da2-9c76-f723c4b59178"),
                    Name = "Drinks"
                },
                new Category
                {
                    Id = new Guid("9072ca4f-1c4b-4abe-9535-876e4d50e005"),
                    Name = "Easy meals"
                },
                new Category
                {
                    Id = new Guid("24735f5d-906d-4c41-9f86-89d19d6620c6"),
                    Name = "New & Seasonal"
                }
            );
        }
    }
}