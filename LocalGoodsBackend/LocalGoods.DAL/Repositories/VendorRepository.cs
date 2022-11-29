using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class VendorRepository : BaseRepository<Guid, Vendor>, IVendorRepository
    {
        public VendorRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
