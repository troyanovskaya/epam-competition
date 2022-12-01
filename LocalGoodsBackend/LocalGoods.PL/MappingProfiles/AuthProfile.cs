using AutoMapper;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.PL.Models.Auth;

namespace LocalGoods.PL.MappingProfiles
{
    public class AuthProfile: Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginRequest, LoginModel>();
            CreateMap<SignupRequest, SignupModel>();
        }
    }
}