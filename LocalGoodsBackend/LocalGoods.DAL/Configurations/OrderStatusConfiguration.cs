using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LocalGoods.Shared;

namespace LocalGoods.DAL.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder
                .HasIndex(ut => ut.Name)
                .IsUnique();

            builder.Property(ut => ut.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(os => os.Orders)
                .WithOne(o => o.OrderStatus);

            builder.HasData
            (
                new OrderStatus
                {
                    Id = GlobalValues.NewOrderStatusId,
                    Name = "New"
                },
                new OrderStatus
                {
                    Id = GlobalValues.PendingOrderStatusId,
                    Name = "Pending"
                },
                new OrderStatus
                {
                    Id = GlobalValues.PaidOrderStatusId,
                    Name = "Paid"
                },
                new OrderStatus
                {
                    Id = GlobalValues.CompletedOrderStatusId,
                    Name = "Completed"
                },
                new OrderStatus
                {
                    Id = GlobalValues.CanceledOrderStatusId,
                    Name = "Canceled"
                }
            );
        }
    }
}
