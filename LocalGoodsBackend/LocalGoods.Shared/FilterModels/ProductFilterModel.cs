using System;

namespace LocalGoods.Shared.FilterModels
{
    public class ProductFilterModel
    {
        public Guid? CityId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
