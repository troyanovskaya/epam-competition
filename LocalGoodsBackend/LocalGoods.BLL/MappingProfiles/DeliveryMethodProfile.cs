using AutoMapper;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class DeliveryMethodProfile: Profile
    {
        public DeliveryMethodProfile()
        {
            CreateMap<DeliveryMethod, DeliveryMethodModel>();
        }
    }
}