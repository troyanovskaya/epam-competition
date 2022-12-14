using System;
using System.Collections.Generic;

namespace LocalGoods.PL.Models.Order
{
    public class OrderRequest
    {
        public IEnumerable<Guid> OrderStatusIds { get; set; }
    }
}
