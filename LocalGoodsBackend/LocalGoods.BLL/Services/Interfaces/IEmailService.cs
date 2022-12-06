using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailConfirmationLinkAsync(string to, string link);
        Task SendResetPasswordLinkAsync(string to, string callback);
    }
}