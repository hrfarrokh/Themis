namespace Themis.Application.Contracts
{
    public interface IExhibitionOrderListQueryHandler
    {
        Task<ListResponse<OrderListDto>> HandleAsync(
            ExhibitionOrderListQuery request,
            CancellationToken ct);
    }
}
