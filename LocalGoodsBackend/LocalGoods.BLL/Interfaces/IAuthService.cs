using System.Threading.Tasks;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.BLL.Models.Auth.JWT;

namespace LocalGoods.BLL.Interfaces
{
    public interface IAuthService
    {
        Task SignupAsync(SignupModel model);
        Task<JwtResponse> LoginAsync(LoginModel model);
    }
}