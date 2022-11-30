using System;

namespace LocalGoods.DAL.Entities
{
    public class VendorDeliveryMethod: EntityBase<Guid>
    {
        public virtual Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }

        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public Guid DeliveryMethodId { get; set; }

        public string Information { get; set; }
    }
}