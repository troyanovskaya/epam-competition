using AutoMapper;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class VendorPaymentMethodProfile : Profile
    {
        public VendorPaymentMethodProfile()
        {
            CreateMap<PaymentInformationModel, VendorPaymentMethod>();
        }
    }
}
