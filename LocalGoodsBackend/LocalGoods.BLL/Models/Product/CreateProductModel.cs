using System;
using System.Collections.Generic;

namespace LocalGoods.BLL.Models.Product
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Poster { get; set; }
        public double Discount { get; set; }
        public Guid VendorId { get; set; }
        public double Amount { get; set; }
        public Guid UnitTypeId { get; set; }

        public IEnumerable<Guid> CategoryIds { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}