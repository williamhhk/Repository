using Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IDisposable
    {
        int SaveChanges();
        TContext Context { get; }
    }
}
