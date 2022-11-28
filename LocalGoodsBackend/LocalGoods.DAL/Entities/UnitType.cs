using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class UnitType: EntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<ProductStorage> ProductStorages { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}