using LocalGoods.DAL.Entities;
using System;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IProductStorageRepository : IRepository<Guid, ProductStorage>
    {
    }
}
