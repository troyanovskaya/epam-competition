using AutoMapper;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.PL.Models.PaymentMethod;

namespace LocalGoods.PL.MappingProfiles
{
    public class PaymentMethodProfilePl: Profile
    {
        public PaymentMethodProfilePl()
        {
            CreateMap<PaymentMethodModel, PaymentMethodResponse>();
        }
    }
}