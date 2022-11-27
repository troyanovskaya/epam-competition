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
                .HasPrecision(12, 10);

            builder
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails);

            builder
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails);
        }
    }
}