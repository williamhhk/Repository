using Repository.Infrastructure;
using System;
using System.Data.Entity;

namespace Repository.DataContext
{
    public static class ContextHelpers
    {
        //Only use with short lived contexts 
        public static void ApplyStateChanges(this DbContext context)
        {
            //foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            //{
            //    IObjectWithState stateInfo = entry.Entity;
            //    entry.State = StateHelpers.ConvertState(stateInfo.State);
            //}
        }
    }

    public class StateHelper
    {
        public static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;

                case ObjectState.Modified:
                    return EntityState.Modified;

                case ObjectState.Deleted:
                    return EntityState.Deleted;

                default:
                    return EntityState.Unchanged;
            }
        }
        public static ObjectState ConvertState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Detached:
                    return ObjectState.Unchanged;

                case EntityState.Unchanged:
                    return ObjectState.Unchanged;

                case EntityState.Added:
                    return ObjectState.Added;

                case EntityState.Deleted:
                    return ObjectState.Deleted;

                case EntityState.Modified:
                    return ObjectState.Modified;

                default:
                    throw new ArgumentOutOfRangeException("state");
            }
        }
    }
}
