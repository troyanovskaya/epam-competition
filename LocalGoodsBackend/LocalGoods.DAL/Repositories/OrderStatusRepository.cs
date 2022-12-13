using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class OrderStatusRepository : BaseRepository<Guid, OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
