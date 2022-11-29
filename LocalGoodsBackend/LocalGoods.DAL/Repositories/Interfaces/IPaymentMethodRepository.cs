using LocalGoods.DAL.Entities;
using System;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IPaymentMethodRepository : IRepository<Guid, PaymentMethod>
    {
    }
}
