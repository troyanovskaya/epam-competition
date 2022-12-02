using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class VendorDeliveryMethodRepository : BaseRepository<Guid, VendorDeliveryMethod>, IVendorDeliveryMethodRepository
    {
        public VendorDeliveryMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public async Task AddRangeAsync(IEnumerable<VendorDeliveryMethod> deliveryMethods)
        {
            await _dbSet.AddRangeAsync(deliveryMethods);
        }
    }
}
