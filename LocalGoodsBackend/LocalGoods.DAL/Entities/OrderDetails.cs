using System;

namespace LocalGoods.DAL.Entities
{
    public class OrderDetails: EntityBase
    {
        public decimal Price { get; set; }
        public double Discount { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}