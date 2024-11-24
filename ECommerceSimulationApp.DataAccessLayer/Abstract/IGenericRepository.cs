using System.Linq.Expressions;

namespace ECommerceSimulationApp.DataAccessLayer.Abstract;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null
        , bool track = true, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetByIdAsync(string id, bool track = true, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetAsync(Expression<Func<T, bool>>? expression, bool track = true);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool track);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Remove(T entity);


}
