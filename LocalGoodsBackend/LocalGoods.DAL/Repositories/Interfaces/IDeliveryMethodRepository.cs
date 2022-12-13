using LocalGoods.DAL.Entities;
using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IDeliveryMethodRepository : IRepository<Guid, DeliveryMethod>
    {
        IEnumerable<Guid> GetExceptIdsAsync(IEnumerable<Guid> deliveryMethodIds);
    }
}
