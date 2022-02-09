namespace Themis.Application.Contracts
{
    public interface IRequestContextService
    {
        Guid GetUserId();
        string GetUsername();
    }
}
