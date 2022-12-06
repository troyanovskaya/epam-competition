﻿using LocalGoods.BLL.Models.Product;
using LocalGoods.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllByFilterAsync(ProductFilterModel productFilterModel);
        Task<IEnumerable<ProductModel>> GetByVendorIdAsync(Guid vendorId);
        Task<ProductModel> GetByIdAsync(Guid id);
        Task<ProductModel> CreateAsync(CreateProductModel createProductModel);
    }
}