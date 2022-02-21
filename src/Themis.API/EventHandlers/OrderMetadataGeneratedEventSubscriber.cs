using Ardalis.GuardClauses;
using MediatR;
using Themis.Application;

namespace Themis.API
{
    public class OrderMetadataGeneratedEventSubscriber
    {
        private readonly IMediator _mediator;

        public OrderMetadataGeneratedEventSubscriber(IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator);
            _mediator = mediator;
        }

        public async Task HandleAsync(
            PlaceOrderMetadataRequest request,
            CancellationToken ct)
        {
            Guard.Against.Null(request);

            await _mediator.Send(request, ct);
        }
    }
}
