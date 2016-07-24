using Repository.Respository;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repository.Extensions
{
    public static class DBSetEx
    {
        public static IEnumerable<T> SqlQuery<T>(this IDbSet<T> set, string query) where T : class
        {
            var dbSet = set as DbSet<T>;
            if (dbSet != null)
            {
                return dbSet.SqlQuery(query);
            }
            throw new NotSupportedException();

        }
    }

    //public static IEnumerable<TOut> Map<T, TOut>
    //    (this IBuffer<T> buffer, Converter<T, TOut> convertor)
    //{
    //    return 
    //}
}
