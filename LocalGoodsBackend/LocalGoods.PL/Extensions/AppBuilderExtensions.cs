using LocalGoods.PL.Middleware;
using Microsoft.AspNetCore.Builder;

namespace LocalGoods.PL.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}