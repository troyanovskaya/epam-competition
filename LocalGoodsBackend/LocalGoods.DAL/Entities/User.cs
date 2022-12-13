using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.DAL.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressInformation { get; set; }
        public Guid CityId { get; set; }
        
        public virtual City City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}