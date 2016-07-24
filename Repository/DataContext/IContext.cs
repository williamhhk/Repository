using Repository.Infrastructure;
using System;
using System.Data.Entity;

namespace Repository.DataContext
{
    public interface IContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
    }
}
