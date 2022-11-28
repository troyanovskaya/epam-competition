using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Order: AuditEntity<Guid>
    {
        public User User { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}