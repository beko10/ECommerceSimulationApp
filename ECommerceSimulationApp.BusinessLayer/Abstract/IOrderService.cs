using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.EmployeeDto;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDto;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface IOrderService
{
    Task<IDataResult<IEnumerable<GetAllOrderDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdOrderDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateOrderDto entity);
    Task<IResult> Update(UpdateOrderDto entity);
    Task<IResult> Remove(DeleteOrderDto entity);
}
