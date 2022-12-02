using AutoMapper;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.DAL.Entities;
using System;

namespace LocalGoods.BLL.MappingProfiles
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<CreateVendorModel, Vendor>();
            CreateMap<Vendor, VendorModel>();
        } 
    }
}
