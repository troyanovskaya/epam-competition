using System;
using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class PaymentMethodConfiguration: IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(p => p.VendorPaymentMethods)
                .WithOne(v => v.PaymentMethod);

            builder
                .HasMany(p => p.Orders)
                .WithOne(o => o.PaymentMethod);

            builder.HasData
            (
                new PaymentMethod
                {
                    Id = new Guid("76cdcb56-30e6-4674-9085-d65a936cae25"),
                    Name = "Card"
                },
                new PaymentMethod
                {
                    Id = new Guid("60d556a7-26d6-4c02-a824-4b6cbdcb110e"),
                    Name = "Cash"
                }
            );
        }
    }
}