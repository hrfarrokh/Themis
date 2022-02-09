namespace Themis.Application.Contracts
{
    public interface IPlaceOrderMetadataHandler
    {
        Task HandleAsync(PlaceOrderMetadataRequest request, CancellationToken ct);
    }
}
