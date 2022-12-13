using System;

namespace LocalGoods.PL.Models.City
{
    public class CityResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}