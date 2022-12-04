﻿using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Extensions;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Guid, Product>, IProductRepository
    {
        public ProductRepository(LocalGoodsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetByFilterAsync(ProductFilterModel productFilterModel)
        {
            return await ((LocalGoodsDbContext)_context).Products
                .FilterByCity(productFilterModel.CityId)
                .FilterByCategories(productFilterModel.CategoryIds)
                .ToListAsync();
        }
    }
}
