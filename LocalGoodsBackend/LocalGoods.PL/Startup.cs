using System;
using System.Text;
using LocalGoods.BLL.Extensions;
using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.PL.Extensions;
using LocalGoods.DAL.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace LocalGoods.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            
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
            
            services.AddAuthorization();
            services
                /*.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })*/
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration.GetSection("JwtSettings")["Issuer"],
                        ValidAudience = Configuration.GetSection("JwtSettings")["Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtSettings")["Key"]))
                    };
                });

            services.AddPresentationLayerServices(Configuration);
            services.AddDataAccessLayerServices(Configuration);
            services.AddBusinessLogicLayerServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseExceptionHandlingMiddleware();

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
