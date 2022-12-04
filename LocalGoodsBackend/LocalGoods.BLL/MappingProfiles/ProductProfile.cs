using AutoMapper;
using LocalGoods.BLL.Models.Product;
using LocalGoods.DAL.Entities;
using System.Linq;

namespace LocalGoods.BLL.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductModel, Product>()
                .ForMember(p => p.Images, cfg => cfg.Ignore())
                .ForMember(p => p.UnitType, cfg => cfg.Ignore());
            CreateMap<Product, ProductModel>()
                .ForMember(pm => pm.Images, cfg => cfg.MapFrom(p => p.Images.Select(i => i.Link)));
        }
    }
}
