using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Adressbuch.WPF.DataAccess
{
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

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T? entityToDelete = _dbSet.Find(id);
            if (null != entityToDelete)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
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
}
