using AutoMapper;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.PL.Models.DeliveryMethod;

namespace LocalGoods.PL.MappingProfiles
{
    public class DeliveryMethodProfilePl: Profile
    {
        public DeliveryMethodProfilePl()
        {
            CreateMap<DeliveryMethodModel, DeliveryMethodResponse>();
        }
    }
}