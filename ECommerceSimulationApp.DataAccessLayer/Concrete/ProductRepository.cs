using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Context;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.DataAccessLayer.Concrete;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
