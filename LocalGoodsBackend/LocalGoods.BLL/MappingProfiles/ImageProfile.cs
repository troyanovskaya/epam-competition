using AutoMapper;
using LocalGoods.BLL.Models.Image;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<CreateImageModel, Image>();
        }
    }
}
