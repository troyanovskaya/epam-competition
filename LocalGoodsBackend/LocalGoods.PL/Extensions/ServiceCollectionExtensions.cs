using LocalGoods.BLL.MappingProfiles;
using LocalGoods.BLL.Models.Auth.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalGoods.PL.Extensions
{
    public static class ServiceCollectionExtensions
    {
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