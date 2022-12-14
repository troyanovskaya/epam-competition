using System;
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
                    AddressInformation = "Some address",
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
                    CityId = new Guid("43809371-4E7D-4616-AC26-D62D202D4767"),
                    EmailConfirmed = true
                },
                new User()
                {
                    Id = new Guid("4483ab90-887a-ed11-b7a9-0003aa002c50"),
                    AddressInformation = "Some address",
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@local.goods",
                    NormalizedEmail = "ADMIN@LOCAL.GOODS",
                    PasswordHash = "AQAAAAEAACcQAAAAEL2R6txwf1WpL6eBtlvvmcS54/Q6STqQUaZlipMREY35Xn2zXt5vxoFtta6ZbpCu9Q==",
                    SecurityStamp = "U5IMACP6NPF4UHCNSEPQY2XRC6QIUL6K",
                    ConcurrencyStamp = "361787c1-69c1-4a6b-8f6b-3ee2721a8c3e",
                    PhoneNumber = "380987654321",
                    CityId = new Guid("e82aafbd-713b-4e12-a4a1-b38378a5a90f"),
                    EmailConfirmed = true
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
                },
                new Role
                {
                    Id = new Guid("71be2e68-fa38-4de3-b253-d34f1c16cc9a"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "baf17a47-bf30-42e1-a31e-fac07868dc02"
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
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("71be2e68-fa38-4de3-b253-d34f1c16cc9a"),
                    UserId = new Guid("4483ab90-887a-ed11-b7a9-0003aa002c50")
                }
            );
        }
    }
}