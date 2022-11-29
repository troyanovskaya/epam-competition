using System;

namespace LocalGoods.BLL.Models.Image
{
    public class CreateImageModel
    {
        public string Link { get; set; }
        public Guid ProductId { get; set; }
    }
}