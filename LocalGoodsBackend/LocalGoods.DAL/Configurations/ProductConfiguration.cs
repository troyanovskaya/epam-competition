using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasPrecision(19, 4);

            builder
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Products);

            builder
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products);

            builder
                .HasMany(p => p.Images)
                .WithOne(i => i.Product);

            builder
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product);

            builder
                .HasMany(p => p.ProductStorages)
                .WithOne(ps => ps.Product);
        }
    }
}