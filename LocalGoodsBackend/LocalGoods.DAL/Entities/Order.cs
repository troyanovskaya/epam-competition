using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LocalGoods.DAL.Entities
{
    public class Order: AuditEntity<Guid>
    {
        public virtual User User { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string PaymentInformation { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public string DeliveryInformation { get; set; }
        
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}