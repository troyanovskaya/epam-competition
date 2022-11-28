using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IRepository<TId, TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(TId id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(TId id);
        Task UpdateAsync(TEntity entity);
        Task<bool> CheckIfEntityExistsById(TId id);
    }
}
