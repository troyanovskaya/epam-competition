using System;
using System.Collections.Generic;
using LocalGoods.BLL.Models.Category;
using LocalGoods.BLL.Models.Image;
using LocalGoods.BLL.Models.UnitType;

namespace LocalGoods.BLL.Models.Product
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Poster { get; set; }
        public double Discount { get; set; }
        public Guid VendorId { get; set; }
        public double Amount { get; set; }
        public UnitTypeModel UnitType { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<ImageModel> Images { get; set; }
    }
}