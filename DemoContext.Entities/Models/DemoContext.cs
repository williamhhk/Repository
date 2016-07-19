using Repository.DataContext;
using Repository.Infrastructure;
using System.Data.Entity;

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
        protected BaseContext() : base("name=InventoryEntities")
        { }
    }

    public partial class DemoDbContext : BaseContext<DemoDbContext>,  IDemoContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            Entry(entity).State = StateHelper.ConvertState(entity.ObjectState);
        }
    }
}