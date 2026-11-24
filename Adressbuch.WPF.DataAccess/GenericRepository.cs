using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public interface IGenericRepository<T> where T : class
{
    T? GetById(
        int id,
        params Expression<Func<T, object>>[] includes);

    List<T> GetAll(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes);
}

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public T? GetById(
        int id,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = ApplyIncludes(_dbSet, includes);
        return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
    }

    public List<T> GetAll(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = ApplyIncludes(_dbSet, includes);

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return query.ToList();
    }

    private static IQueryable<T> ApplyIncludes(
        IQueryable<T> query,
        Expression<Func<T, object>>[] includes)
    {
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}
