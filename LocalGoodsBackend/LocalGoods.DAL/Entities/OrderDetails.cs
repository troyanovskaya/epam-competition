using System;

namespace LocalGoods.DAL.Entities
{
    public class OrderDetails: EntityBase<Guid>
    {
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public double Amount { get; set; }

        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

        public virtual UnitType UnitType { get; set; }
        public Guid UnitTypeId { get; set; }
        
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}