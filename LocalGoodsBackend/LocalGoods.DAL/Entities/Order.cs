using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Order: AuditEntity<Guid>
    {
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}