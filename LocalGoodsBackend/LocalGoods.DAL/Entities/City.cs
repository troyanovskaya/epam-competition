using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class City: EntityBase<Guid>
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}