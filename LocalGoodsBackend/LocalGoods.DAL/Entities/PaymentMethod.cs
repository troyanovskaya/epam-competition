﻿using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class PaymentMethod: EntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<VendorPaymentMethod> VendorPaymentMethods { get; set; }
    }
}