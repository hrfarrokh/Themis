using Ardalis.GuardClauses;
using Themis.Application.Contracts;

namespace Themis.API
{
    public class OrderMetadataGeneratedEventSubscriber
    {
        private readonly IPlaceOrderMetadataHandler _handler;

        public OrderMetadataGeneratedEventSubscriber(IPlaceOrderMetadataHandler handler)
        {
            _handler = Guard.Against.Null(handler);
            _handler = handler;
        }

        public async Task HandleAsync(
            PlaceOrderMetadataRequest request,
            CancellationToken ct)
        {
            Guard.Against.Null(request);

            await _handler.HandleAsync(request, ct);
        }
    }
}
