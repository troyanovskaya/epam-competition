using LocalGoods.DAL.Entities;
using LocalGoods.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.DeliveryInformation)
                .HasMaxLength(1000)
                .IsRequired();
            
            builder
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order);

            builder
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(o => o.PaymentMethod)
                .WithMany(pm => pm.Orders);

            builder
                .HasOne(o => o.DeliveryMethod)
                .WithMany(dm => dm.Orders);

            builder
                .Property(o => o.OrderStatusId)
                .HasDefaultValue(GlobalValues.NewOrderStatusId);
        }
    }
}