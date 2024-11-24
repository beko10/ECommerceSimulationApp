using ECommerceSimulationApp.BusinessLayer.Utilities.Results;
using ECommerceSimulationApp.EntityLayer.Dto.SupplierDto;

namespace ECommerceSimulationApp.BusinessLayer.Abstract;

public interface ISupplierService
{
    Task<IDataResult<IEnumerable<GetAllSupplierDto>>> GetAll(bool track = true);
    Task<IDataResult<GetByIdSupplierDto>> GetByIdAsync(string id, bool track = true);
    Task<IResult> CreateAsync(CreateSupplierDto entity);
    Task<IResult> Update(UpdateSupplierDto entity);
    Task<IResult> Remove(DeleteSupplierDto entity);
}
