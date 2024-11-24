using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.ProductDto;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface IProductService
{
    Task<IDataResult<IEnumerable<GetAllProductDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdProductDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateProductDto entity);
    Task<IResult> Update(UpdateProductDto entity);
    Task<IResult> Remove(DeleteProductDto entity);
}
