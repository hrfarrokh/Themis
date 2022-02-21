namespace Themis.Application
{
    public interface IRequestContextService
    {
        Guid GetUserId();
        string GetUsername();
    }
}
