using System;

namespace LocalGoods.BLL.Models.Filters
{
    public class ProductFilterModel
    {
        public Guid? CityId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
