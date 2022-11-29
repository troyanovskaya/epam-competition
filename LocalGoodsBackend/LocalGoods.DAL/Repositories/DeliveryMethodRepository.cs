using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class DeliveryMethodRepository : BaseRepository<Guid, DeliveryMethod>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
