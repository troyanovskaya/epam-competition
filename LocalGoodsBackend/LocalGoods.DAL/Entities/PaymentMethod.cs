using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class PaymentMethod: EntityBase<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<VendorPaymentMethod> VendorPaymentMethods { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}