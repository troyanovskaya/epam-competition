using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalGoods.BLL.Models.DeliveryMethod;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IDeliveryMethodService
    {
        Task<IEnumerable<DeliveryMethodModel>> GetAllDeliveryMethodsAsync();
        Task<DeliveryMethodModel> GetDeliveryMethodByIdAsync(Guid id);
    }
}