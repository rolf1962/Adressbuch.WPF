using Adressbuch.WPF.Model;

namespace Adressbuch.WPF.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private AdressbuchDbContext _context;
        private GenericRepositoryModelBase<Person> _personRepository;
        private GenericRepositoryModelBase<Adresse> _adresseRepository;
        private GenericRepositoryModelBase<Erreichbarkeit> _erreichbarkeitRepository;

        public UnitOfWork(AdressbuchDbContext dbContext)
        {
            _context = dbContext;
            _personRepository = new GenericRepositoryModelBase<Person>(_context);
            _adresseRepository = new GenericRepositoryModelBase<Adresse>(_context);
            _erreichbarkeitRepository = new GenericRepositoryModelBase<Erreichbarkeit>(_context);
        }

        public GenericRepository<Person> PersonRepository => _personRepository;
        public GenericRepository<Adresse> AdresseRepository => _adresseRepository;
        public GenericRepository<Erreichbarkeit> ErreichbarkeitRepository => _erreichbarkeitRepository;

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
