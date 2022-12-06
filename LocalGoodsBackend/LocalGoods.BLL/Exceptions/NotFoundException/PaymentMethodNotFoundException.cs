using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class PaymentMethodNotFoundException : NotFoundException
    {
        public PaymentMethodNotFoundException() : base() { }

        public PaymentMethodNotFoundException(Guid id) : base($"Payment method with id {id} was not found") { }
    }
}
