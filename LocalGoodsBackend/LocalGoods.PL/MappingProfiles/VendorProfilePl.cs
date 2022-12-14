using AutoMapper;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.PL.Models.Vendor;

namespace LocalGoods.PL.MappingProfiles
{
    public class VendorProfilePl: Profile
    {
        public VendorProfilePl()
        {
            CreateMap<VendorModel, VendorResponse>();
        }
    }
}