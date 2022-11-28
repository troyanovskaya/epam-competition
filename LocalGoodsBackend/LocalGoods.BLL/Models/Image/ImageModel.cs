using System;

namespace LocalGoods.BLL.Models.Image
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public Guid ProductId { get; set; }
    }
}