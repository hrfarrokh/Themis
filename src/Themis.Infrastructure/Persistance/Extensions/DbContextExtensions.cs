using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Themis.Infrastructure.Persistance
{
    public static class DbContextExtensions
    {
        public static DbContext PartialUpdate<T>(
            this DbContext dbContext,
            T entity,
            params Expression<Func<T, object>>[] updatedProperties)
            where T : class
        {
            EntityEntry<T> dbEntityEntry = dbContext.Entry(entity);

            foreach (Expression<Func<T, object>> property in updatedProperties)
            {
                dbEntityEntry.Property(property).IsModified = true;
            }

            return dbContext;
        }
    }
}
