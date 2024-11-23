using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using System.Linq.Expressions;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface ICategoryService
{
    Task<IDataResult<IEnumerable<GetAllCategoryDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdCategoryDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateCategoryDto entity);
    Task<IResult> Update(UpdateCategoryDto entity);
    Task<IResult> Remove(DeleteCategoryDto entity);
}
