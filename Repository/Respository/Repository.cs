using Repository.DataContext;
using Repository.Infrastructure;
using Repository.UnitOfWork;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Repository.Respository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IObjectState
    {
        private readonly IContext _context;
        private readonly IUnitOfWork<IContext> _unitOfWork;
        private IDbSet<TEntity> _entity;

        public Repository(IUnitOfWork<IContext> unitOfWork)
        {
            _context = unitOfWork.Context;
            _unitOfWork = unitOfWork;
        }

        private IDbSet<TEntity> Entity
        {
            get
            {
                if (_entity == null)
                    _entity = _context.Set<TEntity>();
                return _entity;
            }
        }

        public virtual TEntity Find(int id)
        {
            return Entity.Find(id);
        }
        public virtual TEntity Find(params object[] keyValues)
        {
            return Entity.Find(keyValues);
        }

        public virtual void Update(TEntity entity)
        {
            entity.ObjectState = ObjectState.Modified;
            Entity.Attach(entity);
            _context.SyncObjectState(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity.ObjectState == ObjectState.Added)
            {
                Entity.Add(entity);
            }
            else
            {
                entity.ObjectState = ObjectState.Modified;
                Entity.Add(entity);
            }
            _context.SyncObjectState(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            Entity.Attach(entity);
            _context.SyncObjectState(entity);
        }

        public IEnumerable<TEntity> SqlQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
