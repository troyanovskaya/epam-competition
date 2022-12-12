using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Guid, Category>, ICategoryRepository
    {
        public CategoryRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllByIds(IEnumerable<Guid> ids)
        {
            return await ((LocalGoodsDbContext)_context).Categories
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();
        }
    }
}
