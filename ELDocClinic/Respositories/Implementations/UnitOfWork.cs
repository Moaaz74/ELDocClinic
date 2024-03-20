using ELDocClinic.Respositories.Interfaces;

namespace ELDocClinic.Respositories.Implementations
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool Disposing)
        {
            if (this.disposed)
            {
                if (Disposing)
                    _context.Dispose();
            }
            this.disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            IRepository<T> repository = new Repository<T>(_context);
            return repository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
