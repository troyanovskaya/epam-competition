using System;
using System.Collections.Generic;

namespace LocalGoods.BLL.Models.Order
{
    public class CreateOrderModel
    {
        public IEnumerable<Guid> ProductIds { get; set; }
        public Guid UserId { get; set; }
    }
}
