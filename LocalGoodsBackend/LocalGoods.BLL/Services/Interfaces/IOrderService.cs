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
        Task<IEnumerable<OrderModel>> GetAllCurrentUserOrdersByOrderStatusIdsAsync(IEnumerable<Guid> orderStatusIds);
        Task<IEnumerable<OrderModel>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<OrderModel>> GetByVendorIdAsync(Guid vendorId);
        Task<OrderModel> GetByIdAsync(Guid id);
        Task<OrderModel> CreateAsync(CreateOrderModel createOrderModel);
        Task<IEnumerable<OrderStatusModel>> GetAllOrderStatusesAsync();
        Task<OrderStatusModel> GetOrderStatuseByidAsync(Guid orderStatusId);
        Task ChangeStatusAsync(Guid orderId);
        Task CancelAsync(Guid orderId);
    }
}
