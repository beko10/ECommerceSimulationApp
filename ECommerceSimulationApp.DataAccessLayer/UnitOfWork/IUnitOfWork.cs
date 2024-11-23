using ECommerceSimulationApp.DataAccessLayer.Abstract;

namespace ECommerceSimulationApp.DataAccessLayer.UnitOfWork;

public interface IUnitOfWork:IAsyncDisposable
{
    ICategoryRepository CategoryRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }
    IProductRepository ProductRepository { get; }
    ISupplierRepository SupplierRepository { get; }

    Task<int> CommitAsync();
}
