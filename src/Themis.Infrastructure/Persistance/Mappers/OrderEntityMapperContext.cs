using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Themis.Domain;

namespace Themis.Infrastructure.Persistance
{
    public class OrderEntityMapperContext
    {
        public OrderEntityMapperContext(DbContext dbContext,
                                        Order aggregate,
                                        Guid userId,
                                        string username)
        {
            DbContext = Guard.Against.Null(dbContext);
            Aggregate = Guard.Against.Null(aggregate);
            UserId = Guard.Against.Default(userId, nameof(userId));
            Username = Guard.Against.NullOrEmpty(username, nameof(username));
        }

        public DbContext DbContext { get; }
        public Order Aggregate { get; }
        public Guid UserId { get; }
        public string Username { get; }
    }
}
