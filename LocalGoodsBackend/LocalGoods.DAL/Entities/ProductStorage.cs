using System;

namespace LocalGoods.DAL.Entities
{
    public class ProductStorage: EntityBase<Guid>
    {
        public double Amount { get; set; }
        
        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public UnitType UnitType { get; set; }
        public Guid UnitTypeId { get; set; }
    }
}