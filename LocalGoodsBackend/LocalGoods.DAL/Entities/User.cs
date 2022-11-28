using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.DAL.Entities
{
    public class User: IdentityUser<Guid>
    {
        public City City { get; set; }
        public Guid CityId { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}