using AutoMapper;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.BLL.Models.Auth.JWT;
using LocalGoods.PL.Models.Auth;

namespace LocalGoods.PL.MappingProfiles
{
    public class AuthProfilePl: Profile
    {
        public AuthProfilePl()
        {
            CreateMap<LoginRequest, LoginModel>();
            CreateMap<SignupRequest, SignupModel>();
            CreateMap<ConfirmEmailRequest, ConfirmEmailModel>();
        }
    }
}