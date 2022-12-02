using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class VendorPaymentMethodRepository : BaseRepository<Guid, VendorPaymentMethod>, IVendorPaymentMethodRepository
    {
        public VendorPaymentMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public async Task AddRangeAsync(IEnumerable<VendorPaymentMethod> paymentMethods)
        {
            await _dbSet.AddRangeAsync(paymentMethods);
        }
    }
}
