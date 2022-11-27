using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class City: EntityBase<Guid>
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }

        public ICollection<User> Users { get; set; }
    }
}