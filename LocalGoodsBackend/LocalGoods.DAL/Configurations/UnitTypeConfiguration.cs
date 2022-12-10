using System;
using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class UnitTypeConfiguration: IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder
                .HasIndex(ut => ut.Name)
                .IsUnique();
            
            builder.Property(ut => ut.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(ut => ut.Products)
                .WithOne(ps => ps.UnitType);

            builder
                .HasMany(ut => ut.OrderDetails)
                .WithOne(od => od.UnitType);

            builder.HasData(
                new UnitType
                {
                    Id = new Guid("d86d983b-61ed-4e7e-9c14-faa6fde675aa"),
                    Name = "Item"
                },
                new UnitType
                {
                    Id = new Guid("c176f933-0587-4393-bc94-f5062c5f5bc2"),
                    Name = "Kg"
                }
            );
        }
    }
}