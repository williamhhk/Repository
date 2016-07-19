using Repository.DataContext;
using Repository.Infrastructure;
using Repository.UnitOfWork;
using System.Data.Entity;
using System.Linq;

namespace Repository.Respository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IObjectState
    {
        private readonly IContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
            _unitOfWork = unitOfWork;

            var dbContext = _context as DbContext;

            if (dbContext != null)
            {
                _dbSet = dbContext.Set<TEntity>();
            }
            //else
            //{
            //    var fakeContext = context as FakeDbContext;

            //    if (fakeContext != null)
            //    {
            //        _dbSet = fakeContext.Set<TEntity>();
            //    }
            //}
        }

        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public virtual void Update(TEntity entity)
        {
            entity.ObjectState = ObjectState.Modified;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity.ObjectState == ObjectState.Added)
            {
                _dbSet.Add(entity);
            }
            else
            {
                entity.ObjectState = ObjectState.Modified;
                _dbSet.Add(entity);
            }
            _context.SyncObjectState(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
        }

    }
}
