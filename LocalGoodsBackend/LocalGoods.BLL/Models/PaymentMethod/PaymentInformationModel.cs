using System;

namespace LocalGoods.BLL.Models.PaymentMethod
{
    public class PaymentInformationModel
    {
        public Guid PaymentMethodId { get; set; }
        public string Information { get; set; }
    }
}
