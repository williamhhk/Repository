using Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IContext, new()
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
                public IContext Context
        {
            get { return (TContext)_context; }
        }
    }
}
