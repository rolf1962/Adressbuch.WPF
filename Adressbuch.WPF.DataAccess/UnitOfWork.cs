using Adressbuch.WPF.Model;

namespace Adressbuch.WPF.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private AdressbuchDbContext _context = new AdressbuchDbContext();
        private GenericRepository<Person>? _PersonRepository;

        public GenericRepository<Person> PersonRepository
        {
            get
            {

                if (_PersonRepository == null)
                {
                    _PersonRepository = new GenericRepository<Person>(_context);
                }
                return _PersonRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
