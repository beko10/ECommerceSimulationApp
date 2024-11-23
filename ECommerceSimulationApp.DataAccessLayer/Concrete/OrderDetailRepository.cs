using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Context;
using ECommerceSimulationApp.EntityLayer.Entity;

namespace ECommerceSimulationApp.DataAccessLayer.Concrete;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(AppDbContext context) : base(context)
    {
    }
}
