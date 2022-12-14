using AutoMapper;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class VendorDeliveryMethodProfile : Profile
    {
        public VendorDeliveryMethodProfile()
        {
            CreateMap<DeliveryInformationModel, VendorDeliveryMethod>();
        }
    }
}
