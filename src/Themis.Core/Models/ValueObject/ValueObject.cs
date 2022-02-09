using System.Diagnostics.CodeAnalysis;

namespace Themis.Core.Models
{
    public abstract class ValueObject<T> : IEquatable<T>
          where T : ValueObject<T>
    {
        public override bool Equals(object obj)
          => ValueObjectComparer<T>.Instance.Equals((T)this, obj);

        public bool Equals([AllowNull] T other)
          => ValueObjectComparer<T>.Instance.Equals((T)this, other);

        public override int GetHashCode()
          => ValueObjectComparer<T>.Instance.GetHashCode((T)this);

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !left.Equals(right);
        }
    }
}
