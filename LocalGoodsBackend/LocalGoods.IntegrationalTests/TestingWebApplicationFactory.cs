using LocalGoods.DAL.Contexts;
using LocalGoods.PL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using System.Linq;
using LocalGoods.DAL.Entities;

namespace LocalGoods.IntegrationalTests
{
    public class TestingWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public static IList<UnitType> UnitTypes = new List<UnitType>()
        {
            new UnitType() { Id = new Guid("be508c77-6575-4a01-98cd-5fb2b1d848cb"), Name = "Kg" },
            new UnitType() { Id = new Guid("55f6c87d-f2da-4971-bd67-7514669e6eaf"), Name = "Items" }
        };

        public static IList<Category> Categories = new List<Category>()
        {
            new Category() { Id = new Guid("9bc8afad-4ae9-44c3-b0d6-c1899f107489"), Name = "Drinks" },
            new Category() { Id = new Guid("86e17735-2063-4567-8a3a-e9f1d22cbb0a"), Name = "Food" }
        };

        public static IList<Country> Countries = new List<Country>()
        {
            new Country() { Id = new Guid("e22137e8-4a34-4e9c-a959-0e6d86d2fe65"), Name = "Ukraine" },
            new Country() { Id = new Guid("ea2db0cb-5c16-4764-a513-6e9303fe29e8"), Name = "Armenia" }
        };

        public static IList<City> Cities = new List<City>()
        {
            new City() { Id = new Guid("e22137e8-4a34-4e9c-a959-0e6d86d2fe65"), Name = "Kyiv", CountryId = new Guid("e22137e8-4a34-4e9c-a959-0e6d86d2fe65") },
            new City() { Id = new Guid("ea2db0cb-5c16-4764-a513-6e9303fe29e8"), Name = "Yerevan", CountryId = new Guid("ea2db0cb-5c16-4764-a513-6e9303fe29e8") }
        };

        public static IList<DeliveryMethod> DeliveryMethods = new List<DeliveryMethod>()
        {
            new DeliveryMethod() { Id = new Guid("16d4764c-60d8-4720-ab4c-aff9916618f6"), Name = "Courier" },
            new DeliveryMethod() { Id = new Guid("9d82e197-90c7-4f72-9cfc-816c614a0bab"), Name = "Take away" }
        };

        public static IList<PaymentMethod> PaymentMethods = new List<PaymentMethod>()
        {
            new PaymentMethod() { Id = new Guid("35504646-c984-4ac7-9dc2-66f4ea37a28b"), Name = "Card" },
            new PaymentMethod() { Id = new Guid("ee963372-7320-43b3-b467-9702ac1dd770"), Name = "Cash" }
        };

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LocalGoodsDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                var inMemoryServiceCollection = new ServiceCollection()
                    .AddEntityFrameworkProxies()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<LocalGoodsDbContext>(options =>
                {
                    options
                        .UseInMemoryDatabase("InMemoryLocalGoodsTestingDb")
                        .UseInternalServiceProvider(inMemoryServiceCollection)
                        .UseLazyLoadingProxies();
                });

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<LocalGoodsDbContext>();
                    SeedData(context);
                }
            });
        }

        private void SeedData(LocalGoodsDbContext context)
        {
            context.UnitTypes.AddRange(UnitTypes);
            context.Categories.AddRange(Categories);
            context.Countries.AddRange(Countries);
            context.Cities.AddRange(Cities);
            context.DeliveryMethods.AddRange(DeliveryMethods);
            context.PaymentMethods.AddRange(PaymentMethods);
            context.SaveChanges();
        }

    }
}
