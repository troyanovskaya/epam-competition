using System;
using AutoMapper;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class AuthProfile: Profile
    {
        public AuthProfile()
        {
            CreateMap<SignupModel, User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.FirstName + opt.LastName + "_" + Guid.NewGuid()));
        }
    }
}