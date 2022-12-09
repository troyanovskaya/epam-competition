using AutoMapper;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.DAL.Entities;
using System;
using System.Linq;

namespace LocalGoods.BLL.MappingProfiles
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<CreateVendorModel, Vendor>();
            CreateMap<Vendor, VendorModel>()
                .ForMember(dest => dest.PaymentMethods, 
                    src => src.MapFrom(opt => opt.VendorPaymentMethods.Select(vp => vp.PaymentMethod)))
                .ForMember(dest => dest.DeliveryMethods,
                    src => src.MapFrom(opt => opt.VendorDeliveryMethods.Select(vd => vd.DeliveryMethod)));
        } 
    }
}
