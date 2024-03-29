﻿using System;
using System.Collections.Generic;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Product;

namespace LocalGoods.PL.Models.Vendor
{
    public class VendorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ViberNumber { get; set; }
        public string TelegramName { get; set; }
        public string InstagramName { get; set; }
        public Guid UserId { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<PaymentMethodModel> PaymentMethods { get; set; }
        public IEnumerable<DeliveryMethodModel> DeliveryMethods { get; set; }
    }
}