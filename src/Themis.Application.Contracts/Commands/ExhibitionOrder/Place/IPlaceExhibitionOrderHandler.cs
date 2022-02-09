namespace Themis.Application.Contracts
{
    public interface IPlaceExhibitionOrderHandler
    {
        Task<PlaceExhibitionOrderResponse> HandleAsync(
            PlaceExhibitionOrderRequest request,
            CancellationToken ct);
    }
}
