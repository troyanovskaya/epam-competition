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

            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            builder
                .HasOne(u => u.City)
                .WithMany(c => c.Users);
        }
    }
}