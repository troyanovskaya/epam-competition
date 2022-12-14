using System;
using System.Collections.Generic;
using LocalGoods.BLL.Models.City;

namespace LocalGoods.BLL.Models.Country
{
    public class CountryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CityModel> Cities { get; set; }
    }
}