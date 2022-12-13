using AutoMapper;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class PaymentMethodProfile: Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodModel>();
        }
    }
}