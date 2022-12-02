using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalGoods.DAL.Repositories
{
    public class DeliveryMethodRepository : BaseRepository<Guid, DeliveryMethod>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public IEnumerable<Guid> GetExceptIdsAsync(IEnumerable<Guid> deliveryMethodIds)
        {
            return deliveryMethodIds.Except(_dbSet.Select(dm => dm.Id));
        }
    }
}
