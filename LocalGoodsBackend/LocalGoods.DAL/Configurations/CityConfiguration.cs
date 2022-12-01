using System;
using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class CityConfiguration: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .HasOne(city => city.Country)
                .WithMany(country => country.Cities);

            builder
                .HasMany(c => c.Users)
                .WithOne(u => u.City);

            builder.HasData
            (
                new City
                {
                    Id = new Guid("43809371-4e7d-4616-ac26-d62d202d4767"),
                    Name = "Kharkiv",
                    CountryId = new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83")
                },
                new City
                {
                    Id = new Guid("e82aafbd-713b-4e12-a4a1-b38378a5a90f"),
                    Name = "Dnipro",
                    CountryId = new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83")
                },
                new City
                {
                    Id = new Guid("a146ee56-265a-4fd7-9732-5393637220bf"),
                    Name = "Yerevan",
                    CountryId = new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593")
                }
            );
        }
    }
}