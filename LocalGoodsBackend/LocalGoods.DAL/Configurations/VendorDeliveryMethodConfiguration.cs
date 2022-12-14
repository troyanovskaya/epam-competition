using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class VendorDeliveryMethodConfiguration: IEntityTypeConfiguration<VendorDeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<VendorDeliveryMethod> builder)
        {
            builder.Property(vd => vd.Information)
                .IsRequired();

            builder
                .HasOne(vd => vd.Vendor)
                .WithMany(v => v.VendorDeliveryMethods);

            builder
                .HasOne(vd => vd.DeliveryMethod)
                .WithMany(d => d.VendorDeliveryMethods);
        }
    }
}