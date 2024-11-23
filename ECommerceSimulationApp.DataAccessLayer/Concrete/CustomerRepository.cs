using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Context;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.DataAccessLayer.Concrete;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
}
