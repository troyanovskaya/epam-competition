using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class CountryConfiguration: IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasIndex(c => c.Name)
                .IsUnique();
            
            builder.Property(c => c.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasMany(country => country.Cities)
                .WithOne(city => city.Country);
        }
    }
}