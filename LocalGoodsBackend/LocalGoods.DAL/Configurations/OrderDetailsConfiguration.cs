using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class OrderDetailsConfiguration: IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(od => od.Price)
                .HasPrecision(19, 4)
                .IsRequired();

            builder
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails);

            builder
                .HasOne(od => od.UnitType)
                .WithMany(ut => ut.OrderDetails);

            builder
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails);
        }
    }
}