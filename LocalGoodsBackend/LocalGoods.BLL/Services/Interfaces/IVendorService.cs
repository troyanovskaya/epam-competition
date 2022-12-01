using LocalGoods.BLL.Models.Vendor;
using LocalGoods.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorModel>> GetAllByFilterAsync(VendorFilterModel vendorFilterModel);
        Task<VendorModel> GetByIdAsync(Guid id);
        Task CreateAsync(CreateVendorModel createVendorModel);
    }
}
