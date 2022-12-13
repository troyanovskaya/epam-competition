using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Guid, Order>, IOrderRepository
    {
        public OrderRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
