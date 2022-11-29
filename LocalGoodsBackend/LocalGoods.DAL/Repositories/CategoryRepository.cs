using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Guid, Category>, ICategoryRepository
    {
        public CategoryRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
