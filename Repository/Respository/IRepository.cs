using Repository.Infrastructure;
using System.Collections.Generic;

namespace Repository.Respository
{
    public interface IReadOnlyRepository<out TEntity>
    {
        TEntity Find(params object[] keyValues);
        TEntity Find(int Id);
        IEnumerable<TEntity> SqlQuery(string query);
    }

    public interface IWriteOnlyRepository<in TEntity>
    {
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }

    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity>
    { 
    }
}
