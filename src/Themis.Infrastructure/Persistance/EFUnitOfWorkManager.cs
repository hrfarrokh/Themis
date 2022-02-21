using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Themis.Application;

namespace Themis.Infrastructure.Persistance
{
    public class EFUnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly OrderDbContext _dbContext;

        public EFUnitOfWorkManager(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IUnitOfWork> Begin(CancellationToken ct)
        {
            IDbContextTransaction handle = await _dbContext.Database.BeginTransactionAsync(
                IsolationLevel.ReadCommitted,
                ct);

            return new EFUnitOfWork(handle);
        }

        private class EFUnitOfWork : IUnitOfWork
        {
            private IDbContextTransaction _transaction;

            public EFUnitOfWork(IDbContextTransaction transaction)
            {
                _transaction = transaction;
            }

            public Task Commit(CancellationToken ct)
            {
                return _transaction.CommitAsync(ct);
            }

            public Task Rollback(CancellationToken ct)
            {
                return _transaction.RollbackAsync(ct);
            }

            public async ValueTask DisposeAsync()
            {
                await _transaction.DisposeAsync();
                _transaction = null;

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
                GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
            }

        }
    }
}
