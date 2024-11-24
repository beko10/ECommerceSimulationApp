using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDetailDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class OrderDetailsMapping : Profile
{
    public OrderDetailsMapping()
    {
        CreateMap<OrderDetail, GetAllOrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, GetByIdOrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, DeleteOrderDetailDto>().ReverseMap();
    }
}
