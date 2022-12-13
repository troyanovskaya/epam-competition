using AutoMapper;
using LocalGoods.BLL.Models.City;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class CityProfile: Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityModel>();
        }
    }
}