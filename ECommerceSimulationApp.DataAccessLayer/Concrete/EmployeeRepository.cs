using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Context;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.DataAccessLayer.Concrete;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
