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
                    Id = new Guid("f647d6cc-359d-4d42-aca7-3a6f5a691eae"),
                    Name = "Kyiv",
                    CountryId = new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83")
                },
                new City
                {
                    Id = new Guid("7ce5b758-acdc-4bbd-a745-2fbd5a64b598"),
                    Name = "Lviv",
                    CountryId = new Guid("6123c937-478b-43a3-98f7-4c6b6fa2fa83")
                },
                new City
                {
                    Id = new Guid("a146ee56-265a-4fd7-9732-5393637220bf"),
                    Name = "Yerevan",
                    CountryId = new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593")
                },
                new City
                {
                    Id = new Guid("3eff06d7-6e86-4dad-bbb7-b43f3321f83e"),
                    Name = "Gyumri",
                    CountryId = new Guid("b83484f9-092d-4b51-afcb-5dc2450e2593")
                },
                new City
                {
                    Id = new Guid("d0dba58e-9a7f-427b-ad6e-3dba4e2a8af5"),
                    Name = "London",
                    CountryId = new Guid("575f0725-41bc-49b7-9137-37070087ff4d")
                },
                new City
                {
                    Id = new Guid("07d7e41c-b329-4dc0-a9d1-7e0e84b73bba"),
                    Name = "Liverpool",
                    CountryId = new Guid("575f0725-41bc-49b7-9137-37070087ff4d")
                }
            );
        }
    }
}