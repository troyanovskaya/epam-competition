using AutoMapper;
using LocalGoods.BLL.Models.City;
using LocalGoods.PL.Models.City;

namespace LocalGoods.PL.MappingProfiles
{
    public class CityProfilePl: Profile
    {
        public CityProfilePl()
        {
            CreateMap<CityModel, CityResponse>();
        }
    }
}