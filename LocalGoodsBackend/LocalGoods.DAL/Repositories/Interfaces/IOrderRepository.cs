using LocalGoods.DAL.Entities;
using System;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Guid, Order>
    {
    }
}
