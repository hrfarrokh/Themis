using MediatR;
using Themis.Application;

namespace Themis.Infrastructure.Services
{
    public class DefaultTransactionPipline<TRquest, TResponse> : IPipelineBehavior<TRquest, TResponse>
        where TRquest : ICommand<TResponse>
    {
        private readonly IUnitOfWorkManager _manager;

        public DefaultTransactionPipline(IUnitOfWorkManager manager)
        {
            _manager = manager;
        }

        public async Task<TResponse> Handle(TRquest request,
                                            CancellationToken ct,
                                            RequestHandlerDelegate<TResponse> next)
        {
            await using IUnitOfWork handle = await _manager.Begin(ct);

            try
            {
                TResponse response = await next();

                await handle.Commit(ct);

                return response;
            }
            catch
            {
                await handle.Rollback(ct);

                throw;
            }
        }
    }
}
