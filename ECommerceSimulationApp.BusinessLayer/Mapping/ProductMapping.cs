using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.ProductDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, GetAllProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>()
            .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category!.CategoryName))
            .ForMember(dst => dst.SupplierName, opt => opt.MapFrom(src => src.Supplier!.CompanyName))
            .ReverseMap();
        CreateMap<Product, UpdateProductDto>()
            .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category!.CategoryName))
            .ForMember(dst => dst.SupplierName, opt => opt.MapFrom(src => src.Supplier!.CompanyName))
            .ReverseMap();
        CreateMap<Product, DeleteProductDto>().ReverseMap();
    }
}
