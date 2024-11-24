using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.EmployeeDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class EmployeeMapping : Profile
{
    public EmployeeMapping()
    {
        CreateMap<Employee,GetAllEmployeeDto>().ReverseMap();
        CreateMap<Employee,GetByIdEmployeeDto>().ReverseMap();
        CreateMap<Employee,CreateEmployeeDto>().ReverseMap();
        CreateMap<Employee,UpdateEmployeeDto>().ReverseMap();
        CreateMap<Employee,DeleteEmployeeDto>().ReverseMap();
    }
}
