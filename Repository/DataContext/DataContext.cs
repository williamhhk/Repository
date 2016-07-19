using Repository.Infrastructure;
using System.Data.Entity;

namespace Repository.DataContext
{
    public class DataContext : DbContext, IContext
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            Entry(entity).State = StateHelper.ConvertState(entity.ObjectState);
        }
    }
}
