using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
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
                    Id = new Guid("6f0a355f-c0b1-46a3-a93a-94fad9aa1ed3"),
                    Name = "In processing"
                },
                new OrderStatus
                {
                    Id = new Guid("de780f77-888f-44e8-be34-d796f5342b55"),
                    Name = "Paid"
                },
                new OrderStatus
                {
                    Id = GlobalValues.CompletedOrderStatusId,
                    Name = "Completed"
                },
                new OrderStatus
                {
                    Id = new Guid("712572b2-5991-48eb-a882-5b842dcfc5bf"),
                    Name = "Canceled"
                }
            );
        }
    }
}
