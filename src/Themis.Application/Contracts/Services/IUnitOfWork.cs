namespace Themis.Application
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task Commit(CancellationToken ct);
        Task Rollback(CancellationToken ct);
    }
}
