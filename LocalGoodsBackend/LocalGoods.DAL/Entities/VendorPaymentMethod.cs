using System;

namespace LocalGoods.DAL.Entities
{
    public class VendorPaymentMethod: EntityBase<Guid>
    {
        public Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public Guid PaymentMethodId { get; set; }

        public string Information { get; set; }
    }
}