using System.Text;
using FluentValidation;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.BLL.Models.Auth.JWT;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Models.OrderDetails;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Services;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.BLL.Validators.DeliveryInformation;
using LocalGoods.BLL.Validators.Order;
using LocalGoods.BLL.Validators.OrderDetails;
using LocalGoods.BLL.Validators.PaymentInformation;
using LocalGoods.BLL.Validators.Product;
using LocalGoods.BLL.Validators.User;
using LocalGoods.BLL.Validators.Vendor;
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
            services.AddValidators();

            return services;
        }
        
        private static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthorization();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
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
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
            services.AddScoped<IUnitTypeService, UnitTypeService>();

            return services;
        }

        private static IServiceCollection AddValidators(
    this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderModel>, CreateOrderModelValidator>();
            services.AddScoped<IValidator<CreateProductModel>, CreateProductModelValidator>();
            services.AddScoped<IValidator<ConfirmEmailModel>, ConfirmEmailModelValidator>();
            services.AddScoped<IValidator<ForgotPasswordModel>, ForgotPasswordModelValidator>();
            services.AddScoped<IValidator<LoginModel>, LoginModelValidator>();
            services.AddScoped<IValidator<ResetPasswordModel>, ResetPasswordModelValidator>();
            services.AddScoped<IValidator<SignupModel>, SignupModelValidator>();
            services.AddScoped<IValidator<CreateVendorModel>, CreateVendorModelValidator>();

            return services;
        }
    }
}