using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class UnitTypeConfiguration: IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder
                .HasIndex(ut => ut.Name)
                .IsUnique();
            
            builder.Property(ut => ut.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(ut => ut.Products)
                .WithOne(ps => ps.UnitType);

            builder
                .HasMany(ut => ut.OrderDetails)
                .WithOne(od => od.UnitType);
        }
    }
}