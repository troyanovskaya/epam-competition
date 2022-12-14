using System.Threading.Tasks;
using Flurl.Http;
using LocalGoods.BLL.Models.Email;
using LocalGoods.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LocalGoods.BLL.Services
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _configuration;
        
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task SendEmailConfirmationLinkAsync(string to, string link)
        {
            var subject = "Email confirmation on LocalGoods website";
            var body = "Hello! You've signed up on LocalGoods website. " +
                                $"Click here to confirm your account: {link}. " +
                                "Please ignore this email if it wasn't you.";
            
            var url = _configuration.GetConnectionString("LOGICAL_APP_URL");

            var emailModel = new SendEmailModel
            {
                To = to,
                Subject = subject,
                Body = body
            };

            _ = await url
                .PostJsonAsync(emailModel);
        }

        public async Task SendResetPasswordLinkAsync(string to, string callback)
        {
            var subject = "Password Recovery on LocalGoods website";
            var body =
                $"Hello! Click this link to reset your password on LocalGoods website: {callback}. " +
                "Please ignore this email if it wasn't you.";
            
            var url = _configuration.GetConnectionString("LOGICAL_APP_URL");

            var emailModel = new SendEmailModel
            {
                To = to,
                Subject = subject,
                Body = body
            };
            
            _ = await url
                .PostJsonAsync(emailModel);
        }
    }
}