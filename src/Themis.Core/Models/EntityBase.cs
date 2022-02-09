using Ardalis.GuardClauses;

namespace Themis.Core.Models
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
        where TKey : Id
    {
        protected EntityBase(TKey id)
        {
            Id = Guard.Against.Null(id, nameof(id));
        }

        public TKey Id { get; }

        public bool Equals(EntityBase<TKey>? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EntityBase<TKey>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TKey>.Default.GetHashCode(Id);
        }

        public static bool operator ==(EntityBase<TKey>? entity1, EntityBase<TKey>? entity2)
        {
            if (ReferenceEquals(entity1, null) ^ ReferenceEquals(entity2, null))
            {
                return false;
            }

            return ReferenceEquals(entity1, null) || entity1.Equals(entity2);
        }

        public static bool operator !=(EntityBase<TKey>? entity1, EntityBase<TKey>? entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
