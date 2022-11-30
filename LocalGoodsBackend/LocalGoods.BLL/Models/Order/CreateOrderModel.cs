using LocalGoods.BLL.Models.Product;
using System;
using System.Collections.Generic;

namespace LocalGoods.BLL.Models.Order
{
    public class CreateOrderModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public Guid UserId { get; set; }
    }
}
