using System;
using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalGoods.PL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LocalGoodsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection ConfigureIdentity(
            this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<LocalGoodsDbContext>()
                .AddUserStore<UserStore<User, Role, LocalGoodsDbContext, Guid>>()
                .AddRoleStore<RoleStore<Role, LocalGoodsDbContext, Guid>>();

            return services;
        }

        public static IServiceCollection AddRepositories(
    this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDeliveryMethodRepository, DeliveryMethodRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitTypeRepository, UnitTypeRepository>();
            services.AddScoped<IVendorDeliveryMethodRepository, VendorDeliveryMethodRepository>();
            services.AddScoped<IVendorPaymentMethodRepository, VendorPaymentMethodRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();

            return services;
        }
    }
}