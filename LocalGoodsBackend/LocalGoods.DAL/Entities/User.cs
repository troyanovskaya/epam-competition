using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.DAL.Entities
{
    public class User: IdentityUser<Guid>
    {
        public ContactInformation ContactInformation { get; set; }
        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}