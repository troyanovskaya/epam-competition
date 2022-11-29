using System;

namespace LocalGoods.BLL.Models.City
{
    public class CityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}