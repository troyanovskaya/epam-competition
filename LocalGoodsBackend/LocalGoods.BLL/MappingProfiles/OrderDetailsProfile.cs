using AutoMapper;
using LocalGoods.BLL.Models.OrderDetails;
using LocalGoods.DAL.Entities;

namespace LocalGoods.BLL.MappingProfiles
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetails, OrderDetailsModel>();
            CreateMap<CreateOrderDetailsModel, OrderDetails>();
        }
    }
}
