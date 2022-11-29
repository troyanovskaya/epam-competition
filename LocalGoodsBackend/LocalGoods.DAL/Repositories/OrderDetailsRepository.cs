using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class OrderDetailsRepository : BaseRepository<Guid, OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
