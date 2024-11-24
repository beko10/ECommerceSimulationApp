using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Order,GetAllOrderDto>().ReverseMap();
        CreateMap<Order,GetByIdOrderDto>().ReverseMap();
        CreateMap<Order,CreateOrderDto>().ReverseMap();
        CreateMap<Order,UpdateOrderDto>().ReverseMap();
        CreateMap<Order,DeleteOrderDto>().ReverseMap();
    }
}
