﻿using System.Text;
using LocalGoods.BLL.Services;
using LocalGoods.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LocalGoods.BLL.Extensions
{
    public static class BusinessLogicLayerDependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayerServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(configuration);
            services.AddServices();

            return services;
        }
        
        private static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration.GetSection("JwtSettings")["Issuer"],
                        ValidAudience = configuration.GetSection("JwtSettings")["Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings")["Key"]))
                    };
                });

            return services;
        }

        private static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}