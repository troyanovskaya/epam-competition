using AutoMapper;
using LocalGoods.BLL.Models.Order;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>()
                .ForMember(om => om.UserId, cfg => cfg.MapFrom(o => o.User.Id));
            CreateMap<CreateOrderModel, Order>();
        }
    }
}
