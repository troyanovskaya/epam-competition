using AutoMapper;
using LocalGoods.BLL.Models.Category;
using LocalGoods.PL.Models.Category;

namespace LocalGoods.PL.MappingProfiles
{
    public class CategoryProfilePl: Profile
    {
        public CategoryProfilePl()
        {
            CreateMap<CategoryModel, CategoryResponse>();
        }
    }
}