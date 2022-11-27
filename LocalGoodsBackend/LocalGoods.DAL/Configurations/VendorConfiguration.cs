using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class VendorConfiguration: IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(v => v.Name)
                .HasMaxLength(400)
                .IsRequired();
            
            builder
                .HasOne(v => v.User);

            builder
                .HasMany(v => v.PaymentMethods)
                .WithMany(p => p.Vendors);

            builder
                .HasMany(v => v.DeliveryMethods)
                .WithMany(d => d.Vendors);

            builder
                .HasMany(v => v.Products)
                .WithOne(p => p.Vendor);
        }
    }
}