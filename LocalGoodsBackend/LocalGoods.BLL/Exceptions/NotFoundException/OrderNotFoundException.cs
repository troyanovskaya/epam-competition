using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException() : base("Order was not found") { }

        public OrderNotFoundException(Guid id) : base($"Order with id {id} was not found") { }
    }
}
