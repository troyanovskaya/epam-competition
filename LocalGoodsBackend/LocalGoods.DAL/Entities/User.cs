using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.DAL.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public City City { get; set; }
        public Guid CityId { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}