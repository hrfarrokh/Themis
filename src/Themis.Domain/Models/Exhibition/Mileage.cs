using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class Mileage : ValueObject<Mileage>
    {
        public Mileage(int value)
        {
            Value = Guard.Against.Negative(value, nameof(value));
        }

        public int Value { get; }

    }
}
