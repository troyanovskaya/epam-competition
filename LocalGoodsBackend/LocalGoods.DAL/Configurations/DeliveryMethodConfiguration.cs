using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class DeliveryMethodConfiguration: IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(d => d.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(d => d.Vendors)
                .WithMany(v => v.DeliveryMethods);
        }
    }
}