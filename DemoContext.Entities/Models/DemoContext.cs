using Repository.DataContext;
using Repository.Infrastructure;
using System.Data.Entity;
using System;

namespace Demo.Entities.Models
{
    public interface IDemoContext : IContext
    {
    }

    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        public BaseContext(string connection) : base(connection)
        { }
    }

    public partial class DemoDbContext : BaseContext<DemoDbContext>,  IDemoContext
    {
        public DemoDbContext() : base("name=InventoryEntities")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            Entry(entity).State = StateHelper.ConvertState(entity.ObjectState);
        }

        IDbSet<TEntity> IContext.Set<TEntity>() => base.Set<TEntity>();
    }

    public partial class HomeCinemaDbContext : BaseContext<DemoDbContext>, IDemoContext
    {
        public HomeCinemaDbContext() : base("name=HomeCinema")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stock");
        }

        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            Entry(entity).State = StateHelper.ConvertState(entity.ObjectState);
        }

        IDbSet<TEntity> IContext.Set<TEntity>() => base.Set<TEntity>();
    }

}