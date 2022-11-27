using System;

namespace LocalGoods.DAL.Entities
{
    // TODO - Inherit from IdentityUser instead of EntityBase
    public class User: EntityBase
    {
        public Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }
    }
}