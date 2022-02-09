using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class InventoryItemId : ValueObject<InventoryItemId>
    {
        public InventoryItemId(long value)
        {
            Value = Guard.Against.NegativeOrZero(value, nameof(value));
        }

        public long Value { get; }

    }
}
