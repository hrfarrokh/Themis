namespace Themis.Domain
{
    public interface IOrderMetadataRepository
    {
        Task CreateAsync(OrderMetadata aggregate,
                         CancellationToken ct = default);
    }

}
