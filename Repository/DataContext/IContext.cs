using Repository.Infrastructure;
using System;

namespace Repository.DataContext
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
    }
}
