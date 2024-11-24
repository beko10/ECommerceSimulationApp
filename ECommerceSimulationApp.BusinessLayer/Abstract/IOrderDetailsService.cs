using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.OrderDetailDto;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface IOrderDetailsService
{
    Task<IDataResult<IEnumerable<GetAllOrderDetailDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdOrderDetailDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateOrderDetailDto entity);
    Task<IResult> Update(UpdateOrderDetailDto entity);
    Task<IResult> Remove(DeleteOrderDetailDto entity);
}
