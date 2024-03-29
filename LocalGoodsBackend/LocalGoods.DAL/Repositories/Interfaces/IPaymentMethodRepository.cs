﻿using LocalGoods.DAL.Entities;
using System;
using System.Collections.Generic;

namespace LocalGoods.DAL.Repositories.Interfaces
{
    public interface IPaymentMethodRepository : IRepository<Guid, PaymentMethod>
    {
        IEnumerable<Guid> GetExceptIdsAsync(IEnumerable<Guid> paymentMethodIds);
    }
}
