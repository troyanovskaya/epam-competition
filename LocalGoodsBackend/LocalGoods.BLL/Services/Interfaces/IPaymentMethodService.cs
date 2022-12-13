using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalGoods.BLL.Models.PaymentMethod;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodModel>> GetAllPaymentMethodsAsync();
        Task<PaymentMethodModel> GetPaymentMethodByIdAsync(Guid id);
    }
}