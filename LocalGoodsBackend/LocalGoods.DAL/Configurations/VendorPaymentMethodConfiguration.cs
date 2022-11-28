using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class VendorPaymentMethodConfiguration: IEntityTypeConfiguration<VendorPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<VendorPaymentMethod> builder)
        {
            builder.Property(vp => vp.Information)
                .IsRequired();

            builder
                .HasOne(vp => vp.Vendor)
                .WithMany(v => v.VendorPaymentMethods);

            builder
                .HasOne(vp => vp.PaymentMethod)
                .WithMany(p => p.VendorPaymentMethods);
        }
    }
}