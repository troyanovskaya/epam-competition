using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class OrderStatusNotFoundException : NotFoundException
    {
        public OrderStatusNotFoundException() : base("Order status was not found") { }

        public OrderStatusNotFoundException(Guid id) : base($"Order status with id {id} was not found") { }
    }
}
