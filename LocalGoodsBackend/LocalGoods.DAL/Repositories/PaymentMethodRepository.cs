using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalGoods.DAL.Repositories
{
    public class PaymentMethodRepository : BaseRepository<Guid, PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public IEnumerable<Guid> GetExceptIdsAsync(IEnumerable<Guid> paymentMethodIds)
        {
            return paymentMethodIds.Except(_dbSet.Select(dm => dm.Id));
        }
    }
}
