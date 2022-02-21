#nullable disable

using MediatR;

namespace Themis.Application
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
