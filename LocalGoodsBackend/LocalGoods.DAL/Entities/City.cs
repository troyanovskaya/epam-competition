using System;

namespace LocalGoods.DAL.Entities
{
    public class City: EntityBase
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }
    }
}