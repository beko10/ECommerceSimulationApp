using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.EmployeeDto;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface IEmployeeService
{
    Task<IDataResult<IEnumerable<GetAllEmployeeDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdEmployeeDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateEmployeeDto entity);
    Task<IResult> Update(UpdateEmployeeDto entity);
    Task<IResult> Remove(DeleteEmployeeDto entity);
}
