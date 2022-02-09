namespace Themis.Application.Contracts
{
    public interface IExhibitionOrderGetQueryHandler
    {
        Task<OrderDto> HandleAsync(
            ExhibitionOrderGetQuery request,
            CancellationToken ct);
    }
}
