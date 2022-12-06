using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class DeliveryMethodNotFoundException : NotFoundException
    {
        public DeliveryMethodNotFoundException() : base() { }

        public DeliveryMethodNotFoundException(Guid id) : base($"Delivery method with id {id} was not found") { }
    }
}
