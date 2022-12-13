using AutoMapper;
using LocalGoods.BLL.Models.UnitType;
using LocalGoods.PL.Models.UnitType;

namespace LocalGoods.PL.MappingProfiles
{
    public class UnitTypeProfilePl: Profile
    {
        public UnitTypeProfilePl()
        {
            CreateMap<UnitTypeModel, UnitTypeResponse>();
        }
    }
}