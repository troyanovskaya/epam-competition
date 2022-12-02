using LocalGoods.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IVendorPaymentMethodRepository : IRepository<Guid, VendorPaymentMethod>
    {
        public Task AddRangeAsync(IEnumerable<VendorPaymentMethod> paymentMethods);
    }
}
