using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Models.Category;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Repositories.Interfaces;

namespace LocalGoods.BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryModel>>(categories);
        }
    }
}