using MediatR;

namespace Themis.Application
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
