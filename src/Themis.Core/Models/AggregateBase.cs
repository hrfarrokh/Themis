
namespace Themis.Core.Models
{
    public abstract class AggregateBase<TAggregateRoot, TKey> :
        EntityBase<TKey>,
        IAggregateRoot<TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : Id
    {

        protected AggregateBase(TKey id,
                                DateTimeOffset? createdAt = null,
                                DateTimeOffset? modifiedAt = null,
                                 Version? version = null)
            : base(id)
        {
            CreatedAt = createdAt ?? Clock.Now;
            ModifiedAt = modifiedAt ?? Clock.Now;
            Version = version ?? Models.Version.Zero;
        }

        public DateTimeOffset CreatedAt { get; protected set; }
        public DateTimeOffset ModifiedAt { get; protected set; }
        public Version Version { get; }

        protected virtual void UpdateTimestamps()
        {
            if (CreatedAt == default)
                CreatedAt = DateTimeOffset.Now;

            ModifiedAt = DateTimeOffset.Now;
        }

    }
}
