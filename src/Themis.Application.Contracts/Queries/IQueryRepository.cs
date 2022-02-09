#nullable disable

namespace Themis.Application.Contracts
{
    public interface IQueryRepository
    {
        IQueryable<T> Query<T>() where T : class;
    }
}
