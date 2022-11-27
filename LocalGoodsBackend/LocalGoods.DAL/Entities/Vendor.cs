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
        
        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<VendorPaymentMethod> VendorPaymentMethods { get; set; }
        public ICollection<VendorDeliveryMethod> VendorDeliveryMethods { get; set; }
    }
}