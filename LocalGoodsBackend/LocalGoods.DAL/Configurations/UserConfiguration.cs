using System;
using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(u => u.FirstName)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(u => u.AddressInformation)
                .IsRequired();

            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(u => u.City)
                .WithMany(c => c.Users);
        }
    }
}