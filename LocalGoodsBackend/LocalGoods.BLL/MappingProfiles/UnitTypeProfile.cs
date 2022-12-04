using AutoMapper;
using LocalGoods.BLL.Models.UnitType;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class UnitTypeProfile : Profile
    {
        public UnitTypeProfile()
        {
            CreateMap<UnitType, UnitTypeModel>();
        }
    }
}
