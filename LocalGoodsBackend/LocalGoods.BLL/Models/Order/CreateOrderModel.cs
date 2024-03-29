﻿using LocalGoods.BLL.Models.OrderDetails;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocalGoods.BLL.Models.Order
{
    public class CreateOrderModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public string DeliveryInformation { get; set; }
        public IEnumerable<CreateOrderDetailsModel> OrderDetails { get; set; }

    }
}
