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
        }
    }
}