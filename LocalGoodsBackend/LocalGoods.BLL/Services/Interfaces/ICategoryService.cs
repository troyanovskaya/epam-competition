using LocalGoods.BLL.Models.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllAsync();
    }
}
