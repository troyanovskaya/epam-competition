﻿using System;
using LocalGoods.BLL.MappingProfiles;
using LocalGoods.BLL.Models.Auth.JWT;
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

        public static IServiceCollection ConfigureOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            return services;
        }
        
        public static IServiceCollection ConfigureAutoMapper(
            this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuthProfile), typeof(Startup));

            return services;
        }
    }
}