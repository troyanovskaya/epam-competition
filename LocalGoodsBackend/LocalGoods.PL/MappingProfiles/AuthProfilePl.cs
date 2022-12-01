using AutoMapper;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.PL.Models.Auth;

namespace LocalGoods.PL.MappingProfiles
{
    public class AuthProfilePl: Profile
    {
        public AuthProfilePl()
        {
            CreateMap<LoginRequest, LoginModel>();
            CreateMap<SignupRequest, SignupModel>();
        }
    }
}