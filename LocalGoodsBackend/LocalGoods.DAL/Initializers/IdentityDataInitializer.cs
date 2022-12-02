﻿using System;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Initializers
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
        }

        private static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData
            (
                new User()
                {
                    Id = new Guid("3470262F-7571-ED11-B214-D41B81B14CB3"),
                    BirthDate = new DateTime(1978, 10, 19),
                    FirstName = "John",
                    LastName = "Smith",
                    UserName = "JohnSmith", 
                    NormalizedUserName = "JOHNSMITH",
                    Email = "smith@gmail.com",
                    NormalizedEmail = "SMITH@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEDkYL3RUU/7ScDdxXvD9hB8eYViSrUANyvEFA9M3SPX4HVqrKWaSf8GpATYde6Wibw==",
                    SecurityStamp = "7JBROKPX4RLYJCPXDGP2COQ25X2DFUN5",
                    ConcurrencyStamp = "8288ed6b-3972-47c1-a4bc-fa4fa26e02f5",
                    PhoneNumber = "+38012345678",
                    CityId = new Guid("43809371-4E7D-4616-AC26-D62D202D4767")
                }
            );
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData
            (
                new Role
                {
                    Id = new Guid("4096c786-5577-4bb2-80c9-9c105b90e16f"),
                    Name = "Buyer",
                    NormalizedName = "BUYER",
                    ConcurrencyStamp = "d9f4bb7d-7411-4706-995f-560c7e5b1972"
                },
                new Role
                {
                    Id = new Guid("77f9bef5-e093-4c53-9bbe-99afb43d2229"),
                    Name = "Vendor",
                    NormalizedName = "VENDOR",
                    ConcurrencyStamp = "9409fbda-8820-43e1-9bb0-f6c0b2ded749"
                }
            );
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>().HasData
            (
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("4096c786-5577-4bb2-80c9-9c105b90e16f"),
                    UserId = new Guid("3470262F-7571-ED11-B214-D41B81B14CB3")
                }
            );
        }
    }
}