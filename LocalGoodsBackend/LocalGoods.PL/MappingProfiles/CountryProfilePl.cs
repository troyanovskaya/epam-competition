using AutoMapper;
using LocalGoods.BLL.Models.Country;
using LocalGoods.PL.Models.Country;

namespace LocalGoods.PL.MappingProfiles
{
    public class CountryProfilePl: Profile
    {
        public CountryProfilePl()
        {
            CreateMap<CountryModel, CountryResponse>();
        }
    }
}