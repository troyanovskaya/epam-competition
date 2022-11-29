using LocalGoods.DAL.Entities;
using System;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IDeliveryMethodRepository : IRepository<Guid, DeliveryMethod>
    {
    }
}
