using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class DeliveryMethodNotFoundException : NotFoundException
    {
        public DeliveryMethodNotFoundException() { }

        public DeliveryMethodNotFoundException(Guid id) : base($"Delivery method with id {id} was not found") { }
    }
}
