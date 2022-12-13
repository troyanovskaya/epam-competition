using AutoMapper;
using LocalGoods.BLL.Models.Country;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class CountryProfile: Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryModel>();
        }
    }
}