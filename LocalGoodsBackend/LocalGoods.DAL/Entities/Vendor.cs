using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Vendor: AuditEntity<Guid>
    {
        public string Name { get; set; }
        
        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
        public ICollection<DeliveryMethod> DeliveryMethods { get; set; }
    }
}