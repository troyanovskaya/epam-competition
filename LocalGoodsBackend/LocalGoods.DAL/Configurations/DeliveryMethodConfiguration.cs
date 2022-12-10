using System;
using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class DeliveryMethodConfiguration: IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder
                .HasIndex(d => d.Name)
                .IsUnique();

            builder.Property(d => d.Name)
                .HasMaxLength(400)
                .IsRequired();
            
            builder
                .HasMany(d => d.VendorDeliveryMethods)
                .WithOne(v => v.DeliveryMethod);

            builder
                .HasMany(d => d.Orders)
                .WithOne(o => o.DeliveryMethod);

            builder.HasData(
                new DeliveryMethod
                {
                    Id = new Guid("79af055a-7827-4e6e-943d-094f81c75fe2"),
                    Name = "Delivery"
                },
                new DeliveryMethod
                {
                    Id = new Guid("152d8dc9-6f20-44d4-82fd-c5e9f4ef299b"),
                    Name = "Takeaway"
                }
            );
        }
    }
}