using LocalGoods.BLL.Models.Order;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderModel createOrderModel);
    }
}
