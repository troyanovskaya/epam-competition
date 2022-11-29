using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class PaymentMethodRepository : BaseRepository<Guid, PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
