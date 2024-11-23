using AutoMapper;
using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.BusinessLayer.Mapping;

public class CategoryMapping:Profile
{
    public CategoryMapping()
    {
        CreateMap<Category,GetAllCategoryDto>().ReverseMap();
        CreateMap<Category,GetByIdCategoryDto>().ReverseMap();
        CreateMap<Category,CreateCategoryDto>().ReverseMap();
        CreateMap<Category,UpdateCategoryDto>().ReverseMap();
        CreateMap<Category,DeleteCategoryDto>().ReverseMap();
    }
}
