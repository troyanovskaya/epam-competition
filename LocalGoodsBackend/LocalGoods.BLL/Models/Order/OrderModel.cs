using System;
using System.Collections.Generic;
using LocalGoods.BLL.Models.OrderDetails;
using LocalGoods.BLL.Models.OrderStatus;

namespace LocalGoods.BLL.Models.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public string DeliveryInformation { get; set; }
        public Guid OrderStatusId { get; set; }
        public IEnumerable<OrderDetailsModel> OrderDetails { get; set; }
    }
}