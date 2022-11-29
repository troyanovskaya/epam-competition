using System;

namespace LocalGoods.BLL.Models.OrderDetails
{
    public class OrderDetailsModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public double Amount { get; set; }
        public Guid ProductId { get; set; }
        public Guid UnitTypeId { get; set; }
        public Guid OrderId { get; set; }
    }
}