using Repository.Infrastructure;


namespace Repository.Respository
{
    public interface IRepository<TEntity> where TEntity : class, IObjectState
    { 
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(params object[] keyValues);
    }
}
