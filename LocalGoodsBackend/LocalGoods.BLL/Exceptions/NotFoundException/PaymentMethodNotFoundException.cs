using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class PaymentMethodNotFoundException : NotFoundException
    {
        public PaymentMethodNotFoundException() { }

        public PaymentMethodNotFoundException(Guid id) : base($"Payment method with id {id} was not found") { }
    }
}
