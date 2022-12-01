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
            services.AddAutoMapper(typeof(AuthProfile), typeof(Startup));

            return services;
        }

        private static IServiceCollection AddHttpContextAccessor(
            this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            return services;
        }
    }
}