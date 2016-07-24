using NHibernate;
using System;
using System.Collections.Generic;

namespace Repository.Respository
{
    public class NHibernateRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        protected ISession Session { get { return _session; } }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(int Id)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SqlQuery(string query)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
