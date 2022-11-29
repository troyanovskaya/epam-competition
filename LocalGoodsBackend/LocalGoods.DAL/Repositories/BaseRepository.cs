using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public abstract class BaseRepository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : EntityBase<TId>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(LocalGoodsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _dbSet.Where(filter);
            return await entities.ToListAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(TId id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async virtual Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async virtual Task DeleteByIdAsync(TId id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task<bool> CheckIfEntityExistsByIdAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }
    }
}
