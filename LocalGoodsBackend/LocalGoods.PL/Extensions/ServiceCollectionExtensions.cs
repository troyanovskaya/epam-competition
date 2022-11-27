using System;
using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
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
    }
}