using LocalGoods.DAL.Entities;
using System;
using System.Linq;

namespace LocalGoods.DAL.Extensions
{
    public static class VendorsQueryableExtension
    {
        public static IQueryable<Vendor> FilterByCity(this IQueryable<Vendor> vendors, Guid? cityId)
        {
            if (cityId is null)
            {
                return vendors;
            }

            return vendors.Where(v => v.User.CityId == cityId);
        }
    }
}
