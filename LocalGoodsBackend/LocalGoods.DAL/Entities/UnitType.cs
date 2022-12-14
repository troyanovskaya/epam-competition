using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class UnitType: EntityBase<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}