using System;
using System.Collections.Generic;
using LocalGoods.PL.Models.City;

namespace LocalGoods.PL.Models.Country
{
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CityResponse> Cities { get; set; }
    }
}