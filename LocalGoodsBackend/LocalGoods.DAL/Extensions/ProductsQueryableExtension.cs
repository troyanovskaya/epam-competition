using LocalGoods.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalGoods.DAL.Extensions
{
    public static class ProductsQueryableExtension
    {
        public static IQueryable<Product> FilterByCity(this IQueryable<Product> products, Guid? cityId)
        {
            if (cityId is null)
            {
                return products;
            }

            return products.Where(p => p.Vendor.User.CityId == cityId);
        }

        public static IQueryable<Product> FilterByCategories(this IQueryable<Product> products, IEnumerable<Guid> categoryIds)
        {
            if (categoryIds is null || !categoryIds.Any())
            {
                return products;
            }

            return products.Where(p => p.Categories.Any(c => categoryIds.Contains(c.Id)));
        }
    }
}
