using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Themis.Application.Contracts;

namespace Themis.Infrastructure.Persistance
{
    public sealed class OrderDbContext : DbContext, IQueryRepository
    {
        public static string ConnectionStringKey = "SqlServer";
        private readonly ILogger<OrderDbContext> _logger;

        public OrderDbContext(DbContextOptions<OrderDbContext> options,
                              ILogger<OrderDbContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        public IQueryable<T> Query<T>() where T : class => Set<T>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("ord");

            builder.ApplyConfigurationsFromAssembly(typeof(OrderEntityConfiguration).Assembly);
            _logger.LogTrace("Configuration Applied.");

            foreach (var entity in builder.Model.GetEntityTypes()
                                                .Where(e => !e.IsOwned()))
            {
                var tableNamePrefix = "Entity";
                var currentTableName = entity.DisplayName();
                var newTableName = currentTableName.Replace(tableNamePrefix, string.Empty);

                _logger.LogTrace($"The old table name: {currentTableName} new table name: {newTableName}");

                entity.SetTableName(newTableName);
            }

        }

    }
}
