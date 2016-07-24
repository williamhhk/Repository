using Repository.DataContext;
using Repository.Extensions;
using Repository.Infrastructure;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Respository
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IObjectState
    {
        private readonly IContext _context;
        private readonly IUnitOfWork<IContext> _unitOfWork;
        private IDbSet<TEntity> _entity;

        public ReadOnlyRepository(IUnitOfWork<IContext> unitOfWork)
        {
            _context = unitOfWork.Context;
            _unitOfWork = unitOfWork;
        }

        private IDbSet<TEntity> Entity => _entity != null ? _entity : _context.Set<TEntity>();


        public TEntity Find(int id) => Entity.Find(id);

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SqlQuery(string query)
        {
            return Entity.SqlQuery(query);
            //var entity = Entity as DbSet<TEntity>;
            //return entity.SqlQuery(query);
        }
    }

}
