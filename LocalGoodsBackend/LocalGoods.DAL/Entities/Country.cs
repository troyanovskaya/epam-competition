using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Entities
{
    public class Country: EntityBase<Guid>
    {
        public string Name { get; set; }
        
        public virtual ICollection<City> Cities { get; set; }
    }
}