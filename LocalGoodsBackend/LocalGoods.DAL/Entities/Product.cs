using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Product: AuditEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Poster { get; set; }
        public double Discount { get; set; }
        public double Amount { get; set; }

        public virtual Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }
        
        public virtual UnitType UnitType { get; set; }
        public Guid UnitTypeId { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}