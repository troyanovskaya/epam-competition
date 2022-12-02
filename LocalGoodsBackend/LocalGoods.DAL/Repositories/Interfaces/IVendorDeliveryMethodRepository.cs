using LocalGoods.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IVendorDeliveryMethodRepository : IRepository<Guid, VendorDeliveryMethod>
    {
        Task AddRangeAsync(IEnumerable<VendorDeliveryMethod> deliveryMethods);
    }
}
