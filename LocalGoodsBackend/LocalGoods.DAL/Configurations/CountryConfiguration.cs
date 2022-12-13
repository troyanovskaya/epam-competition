using System;
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

            builder.HasData
            (
                new Country
                {
                    Id = new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83"),
                    Name = "Ukraine"
                },
                new Country
                {
                    Id = new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593"),
                    Name = "Armenia"
                },
                new Country
                {
                    Id = new Guid("575f0725-41bc-49b7-9137-37070087ff4d"),
                    Name = "England"
                }
            );
        }
    }
}