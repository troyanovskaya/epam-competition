using AutoMapper;
using LocalGoods.BLL.Models.User;
using LocalGoods.PL.Models.User;

namespace LocalGoods.PL.MappingProfiles
{
    public class UserProfilePl: Profile
    {
        public UserProfilePl()
        {
            CreateMap<UserModel, UserResponse>();
        }
    }
}