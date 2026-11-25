using Adressbuch.WPF.Model;
using System.Security.Principal;

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
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
            string userName = WindowsIdentity.GetCurrent().Name;
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen

            _context = dbContext;
            _personRepository = new GenericRepositoryModelBase<Person>(_context, userName);
            _adresseRepository = new GenericRepositoryModelBase<Adresse>(_context, userName);
            _erreichbarkeitRepository = new GenericRepositoryModelBase<Erreichbarkeit>(_context, userName);
        }

        public GenericRepositoryModelBase<Person> PersonRepository => _personRepository;
        public GenericRepositoryModelBase<Adresse> AdresseRepository => _adresseRepository;
        public GenericRepositoryModelBase<Erreichbarkeit> ErreichbarkeitRepository => _erreichbarkeitRepository;

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
