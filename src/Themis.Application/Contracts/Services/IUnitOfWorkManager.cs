namespace Themis.Application
{
    public interface IUnitOfWorkManager
    {
        Task<IUnitOfWork> Begin(CancellationToken ct);
    }
}
