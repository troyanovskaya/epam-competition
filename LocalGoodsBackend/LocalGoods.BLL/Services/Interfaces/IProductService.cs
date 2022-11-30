using LocalGoods.BLL.Models.Filters;
using LocalGoods.BLL.Models.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductModel>> GetByFilterAsync(ProductFilterModel productFilterModel);
        public Task<IEnumerable<ProductModel>> GetByVendorId(Guid id);
        public Task<ProductModel> GetByIdAsync(Guid id);
        public Task CreateAsync(CreateProductModel createProductModel);
    }
}
