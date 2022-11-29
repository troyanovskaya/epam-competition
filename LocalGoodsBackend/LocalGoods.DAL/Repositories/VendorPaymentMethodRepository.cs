using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class VendorPaymentMethodRepository : BaseRepository<Guid, VendorPaymentMethod>, IVendorPaymentMethodRepository
    {
        public VendorPaymentMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
