using System;

namespace LocalGoods.BLL.Models.OrderDetails
{
    public class CreateOrderDetailsModel
    {
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public double Amount { get; set; }
        public Guid ProductId { get; set; }
        public Guid UnitTypeId { get; set; }
        public Guid OrderId { get; set; }
    }
}