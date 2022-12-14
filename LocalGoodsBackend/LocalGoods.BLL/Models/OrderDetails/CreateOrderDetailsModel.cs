using System;
using System.Text.Json.Serialization;

namespace LocalGoods.BLL.Models.OrderDetails
{
    public class CreateOrderDetailsModel
    {
        [JsonIgnore]
        public decimal Price { get; set; }
        [JsonIgnore]
        public double Discount { get; set; }
        public double Amount { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Guid UnitTypeId { get; set; }
        [JsonIgnore]
        public Guid OrderId { get; set; }
    }
}