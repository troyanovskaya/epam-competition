using System;
using System.Collections.Generic;
using LocalGoods.BLL.Models.OrderDetails;

namespace LocalGoods.BLL.Models.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }

        public IEnumerable<OrderDetailsModel> OrderDetails { get; set; }
    }
}