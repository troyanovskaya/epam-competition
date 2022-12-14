using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Extensions;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class VendorRepository : BaseRepository<Guid, Vendor>, IVendorRepository
    {
        public VendorRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Vendor>> GetByFilterAsync(VendorFilterModel vendorFilterModel)
        {
            return await _dbSet
                .AsQueryable()
                .FilterByCity(vendorFilterModel.CityId)
                .ToListAsync();
        }

        public async Task<Vendor> GetByUserIdAsync(Guid id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(v => v.UserId == id);
        }

        public async Task<Vendor> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(v => v.Name == name);
        }

        public async Task<Vendor> GetByProductIdAsync(Guid id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(v => v.Products.Any(p => p.Id == id));
        }

        public async Task<Vendor> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(v => v.UserId == userId);
        }
    }
}
