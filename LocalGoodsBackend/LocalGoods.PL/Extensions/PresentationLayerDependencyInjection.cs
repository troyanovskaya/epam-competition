﻿using AutoMapper;
using LocalGoods.BLL.MappingProfiles;
using LocalGoods.BLL.Models.Auth.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalGoods.PL.Extensions
{
    public static class PresentationLayerDependencyInjection
    {
        public static IServiceCollection AddPresentationLayerServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions(configuration);
            services.AddAutomapper();
            services.AddHttpContextAccessor();
            services.AddCors();

            return services;
        }
        
        private static IServiceCollection AddOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            return services;
        }
        
        private static IServiceCollection AddAutomapper(
            this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LocalGoods.PL.MappingProfiles.AuthProfile());
                mc.AddProfile(new AuthProfile());
                mc.AddProfile(new VendorProfile());
                mc.AddProfile(new VendorDeliveryMethodProfile());
                mc.AddProfile(new VendorPaymentMethodProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }

        private static IServiceCollection AddHttpContextAccessor(
            this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            return services;
        }
        
        private static IServiceCollection AddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });

            return services;
        }
    }
}