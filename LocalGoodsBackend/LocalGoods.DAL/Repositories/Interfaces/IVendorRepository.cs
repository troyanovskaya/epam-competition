using LocalGoods.DAL.Entities;
using LocalGoods.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IVendorRepository : IRepository<Guid, Vendor>
    {
        Task<IEnumerable<Vendor>> GetByFilterAsync(VendorFilterModel vendorFilterModel);
        Task<Vendor> GetByProductIdAsync(Guid id);
    }
}
