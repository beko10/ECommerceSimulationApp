using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.SupplierDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class SupplierMapping : Profile
{
    public SupplierMapping()
    {
        CreateMap<Supplier, GetAllSupplierDto>().ReverseMap();
        CreateMap<Supplier, GetByIdSupplierDto>().ReverseMap();
        CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
        CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
        CreateMap<Supplier, DeleteSupplierDto>().ReverseMap();
    }
}
