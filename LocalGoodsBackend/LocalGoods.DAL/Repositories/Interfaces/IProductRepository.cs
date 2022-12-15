using LocalGoods.DAL.Entities;
using LocalGoods.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Guid, Product>
    {
        Task<IEnumerable<Product>> GetByFilterAsync(ProductFilterModel productFilterModel);
        Task<IEnumerable<Product>> GetAllByIds(IEnumerable<Guid> ids);
        Task SoftDeleteAsync(Guid id);
    }
}
