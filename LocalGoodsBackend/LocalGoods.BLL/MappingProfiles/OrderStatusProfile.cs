using AutoMapper;
using LocalGoods.BLL.Models.OrderStatus;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class OrderStatusProfile : Profile
    {
        public OrderStatusProfile()
        {
            CreateMap<OrderStatus, OrderStatusModel>();
        }
    }
}
