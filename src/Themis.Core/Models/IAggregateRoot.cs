
namespace Themis.Core.Models
{
    public interface IAggregateRoot<out TKey> : IEntity<TKey>
        where TKey : Id
    {

    }
}
