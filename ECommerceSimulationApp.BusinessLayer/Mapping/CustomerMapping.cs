using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.CustomerDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer,GetAllCustomerDto>().ReverseMap();
        CreateMap<Customer,GetByIdCustomerDto>().ReverseMap();
        CreateMap<Customer,CreateCustomerDto>().ReverseMap();
        CreateMap<Customer,UpdateCustomerDto>().ReverseMap();
        CreateMap<Customer,DeleteCustomerDto>().ReverseMap();
    }
}
