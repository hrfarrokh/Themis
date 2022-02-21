#nullable disable

namespace Themis.Application
{
    public interface IQueryRepository
    {
        IQueryable<T> Query<T>() where T : class;
    }
}
