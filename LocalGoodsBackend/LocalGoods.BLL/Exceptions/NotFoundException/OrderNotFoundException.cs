using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException() { }

        public OrderNotFoundException(Guid id) : base($"Order with id {id} was not found") { }
    }
}
