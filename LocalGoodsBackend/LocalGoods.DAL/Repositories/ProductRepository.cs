using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Extensions;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Guid, Product>, IProductRepository
    {
        public ProductRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetByFilterAsync(ProductFilterModel productFilterModel)
        {
            return await ((LocalGoodsDbContext)_context).Products
                .FilterByCity(productFilterModel.CityId)
                .FilterByCategories(productFilterModel.CategoryIds)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByIds(IEnumerable<Guid> ids)
        {
            return await _dbSet
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
