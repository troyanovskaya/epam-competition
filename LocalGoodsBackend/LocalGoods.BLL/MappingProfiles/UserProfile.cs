using AutoMapper;
using LocalGoods.BLL.Models.User;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}