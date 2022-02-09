using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class FullName : ValueObject<FullName>
    {
        public FullName(string value)
        {
            Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        }

        public string Value { get; }

    }
}
