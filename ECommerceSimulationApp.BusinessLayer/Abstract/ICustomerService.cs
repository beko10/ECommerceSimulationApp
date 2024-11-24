using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.CategoryDto;
using ECommerceSimulationApp.EntityLayer.Dto.CustomerDto;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface ICustomerService
{
    Task<IDataResult<IEnumerable<GetAllCustomerDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdCustomerDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateCustomerDto entity);
    Task<IResult> Update(UpdateCustomerDto entity);
    Task<IResult> Remove(DeleteCustomerDto entity);
}
