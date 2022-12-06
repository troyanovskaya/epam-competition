using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Order: AuditEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public string DeliveryInformation { get; set; }
        
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}