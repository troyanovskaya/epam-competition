using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Category: EntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}