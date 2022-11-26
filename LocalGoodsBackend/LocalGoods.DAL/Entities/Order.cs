using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Order: EntityBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public User UserId { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}