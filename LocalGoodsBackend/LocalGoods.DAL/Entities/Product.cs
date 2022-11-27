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

        public Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }
        
        public ICollection<Category> Categories { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}