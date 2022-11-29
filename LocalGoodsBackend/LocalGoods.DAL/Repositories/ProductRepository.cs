using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Guid, Product>, IProductRepository
    {
        public ProductRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
