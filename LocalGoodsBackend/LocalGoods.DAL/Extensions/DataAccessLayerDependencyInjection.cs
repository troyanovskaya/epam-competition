using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace LocalGoods.DAL.Extensions
{
    public static class DataAccessLayerDependencyInjection
    {
        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddMyDbContext(services, configuration);
            AddIdentity(services);
            AddRepositories(services);

            return services;
        }

        private static void AddMyDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LocalGoodsDbContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies();
            });
        }

        private static IServiceCollection AddIdentity(
            this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opt =>
                {
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<LocalGoodsDbContext>()
                .AddUserStore<UserStore<User, Role, LocalGoodsDbContext, Guid>>()
                .AddRoleStore<RoleStore<Role, LocalGoodsDbContext, Guid>>();

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
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
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
        }
    }
}
