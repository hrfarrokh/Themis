namespace Themis.Core.Models
{
    public interface IEntity<out TKey>
        where TKey : Id
    {
        TKey Id { get; }
    }
}
