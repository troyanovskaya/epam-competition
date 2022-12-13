using System;
using System.Collections.Generic;

namespace LocalGoods.Shared.FilterModels
{
    public class ProductFilterModel
    {
        public Guid? CityId { get; set; }
        public IEnumerable<Guid>? CategoryIds { get; set; }
    }
}
