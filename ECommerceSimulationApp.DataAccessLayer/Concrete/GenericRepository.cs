using ECommerceSimulationApp.DataAccessLayer.Abstract;
using ECommerceSimulationApp.DataAccessLayer.Context;
using ECommerceSimulationApp.EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceSimulationApp.DataAccessLayer.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{

    private readonly AppDbContext _context;
    private DbSet<T> _dbSet => _context.Set<T>();

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null, bool track = true, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        if (!track)
        {
            query = query.AsNoTracking();
        }

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (includeProperties.Any())
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }

        return query;
    }

    public async Task<T> GetByIdAsync(string id, bool track = true, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        if (!track)
        {
            query = query.AsNoTracking();
        }

        if (includeProperties.Any())
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }

        return (await query.FirstOrDefaultAsync(x => x.Id == id))!;
    }
    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool track)
    {
        var query = _dbSet.AsQueryable();

        if (!track)
        {
            query = query.AsNoTracking();
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        return query;
    }
}
