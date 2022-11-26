using System;

namespace LocalGoods.DAL.Entities
{
    public class Order: EntityBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}