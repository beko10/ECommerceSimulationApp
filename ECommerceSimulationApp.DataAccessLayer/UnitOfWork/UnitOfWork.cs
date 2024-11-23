using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Concrete;
using ECommerceSimulationApp.DataAccessLayer.Context;

namespace ECommerceSimulationApp.DataAccessLayer.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private CategoryRepository _categoryRepository;
    private CustomerRepository _customerRepository;
    private EmployeeRepository _employeeRepository;
    private OrderRepository _orderRepository;
    private OrderDetailRepository _orderDetailRepository;
    private ProductRepository _productRepository;
    private SupplierRepository _supplierRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ICategoryRepository CategoryRepository => _categoryRepository ?? (_categoryRepository = new(_context));

    public ICustomerRepository CustomerRepository => _customerRepository ?? (_customerRepository = new(_context));

    public IEmployeeRepository EmployeeRepository => _employeeRepository ?? (_employeeRepository = new(_context));

    public IOrderRepository OrderRepository => _orderRepository ?? (_orderRepository = new(_context));

    public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository ?? (_orderDetailRepository = new(_context));

    public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new(_context));

    public ISupplierRepository SupplierRepository => _supplierRepository ?? (_supplierRepository = new(_context));

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
