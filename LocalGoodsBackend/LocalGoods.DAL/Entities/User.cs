using System;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.DAL.Entities
{
    // TODO - Inherit from IdentityUser instead of EntityBase
    public class User: IdentityUser<Guid>
    {
        public Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }
    }
}