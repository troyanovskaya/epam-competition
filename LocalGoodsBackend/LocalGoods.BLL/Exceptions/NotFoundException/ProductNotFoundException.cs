using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException() : base("Product was not found") { }

        public ProductNotFoundException(Guid id) : base($"Product with id {id} was not found") { }
    }
}
