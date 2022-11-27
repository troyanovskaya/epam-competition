using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class DeliveryMethod: EntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<Vendor> Vendors { get; set; }
    }
}