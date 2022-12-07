using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Models.OrderStatus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<OrderModel> GetByIdAsync(Guid id);
        Task<OrderModel> CreateAsync(CreateOrderModel createOrderModel);
        Task<IEnumerable<OrderStatusModel>> GetAllOrderStatusesAsync();
        Task ChangeStatusAsync(Guid orderId, Guid orderStatusId);
    }
}
