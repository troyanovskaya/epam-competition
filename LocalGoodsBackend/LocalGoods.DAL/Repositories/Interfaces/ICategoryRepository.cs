using LocalGoods.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Guid, Category>
    {
        Task<IEnumerable<Category>> GetAllByIds(IEnumerable<Guid> ids);
    }
}
