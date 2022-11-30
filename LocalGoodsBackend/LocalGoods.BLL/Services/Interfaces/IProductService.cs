using LocalGoods.BLL.Models.Filters;
using LocalGoods.BLL.Models.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetByFilterAsync(ProductFilterModel productFilterModel);
        Task<IEnumerable<ProductModel>> GetByVendorIdAsync(Guid id);
        Task<ProductModel> GetByIdAsync(Guid id);
        Task CreateAsync(CreateProductModel createProductModel);
    }
}
