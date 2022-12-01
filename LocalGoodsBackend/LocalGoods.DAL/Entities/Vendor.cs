using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Vendor: AuditEntity<Guid>
    {
        public string Name { get; set; }
        public string ViberNumber { get; set; }
        public string TelegramName { get; set; }
        public string InstagramName { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<VendorPaymentMethod> VendorPaymentMethods { get; set; }
        public virtual ICollection<VendorDeliveryMethod> VendorDeliveryMethods { get; set; }
    }
}