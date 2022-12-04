using System;

namespace LocalGoods.DAL.Entities
{
    public class VendorPaymentMethod: EntityBase<Guid>
    {
        public Guid VendorId { get; set; }
        public Guid PaymentMethodId { get; set; }
        
        public virtual Vendor Vendor { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}