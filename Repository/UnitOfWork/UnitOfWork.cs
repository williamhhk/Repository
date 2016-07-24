using Repository.DataContext;

namespace Repository.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork <TContext> where TContext : IContext, new()
    {
        private readonly IContext _context;
        public UnitOfWork()
        {
            _context = new TContext();
        }
        public UnitOfWork(IContext context)
        {
            _context = context;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public TContext Context
        {
            get { return (TContext)_context; }
        }
    }
}
