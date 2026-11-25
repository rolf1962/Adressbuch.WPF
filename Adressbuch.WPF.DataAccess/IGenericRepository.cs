using System.Linq.Expressions;

namespace Adressbuch.WPF.DataAccess
{
    internal interface IGenericRepository<T> where T : class
    {
        T? GetById(
            int id,
            params Expression<Func<T, object>>[] includes);

        List<T> GetAll(
            Expression<Func<T, bool>>? predicate = null,
            params Expression<Func<T, object>>[] includes);

        public void Insert(T entity);

        public void Delete(object id);

        public void Delete(T entityToDelete);

        public void Update(T entityToUpdate);
    }
}
