using System;

namespace LocalGoods.DAL.Entities
{
    public class Image: EntityBase<Guid>
    {
        public string Link { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}