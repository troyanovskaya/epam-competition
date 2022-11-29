using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class VendorDeliveryMethodRepository : BaseRepository<Guid, VendorDeliveryMethod>, IVendorDeliveryMethodRepository
    {
        public VendorDeliveryMethodRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
