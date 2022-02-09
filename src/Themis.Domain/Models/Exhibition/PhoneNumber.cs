using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class PhoneNumber : ValueObject<PhoneNumber>
    {
        public static readonly string Pattern = @"((^(09)[0-9]{9}$)|(^(\+98|0)?9\d{9}$))";

        public PhoneNumber(string value)
        {
            Value = Guard.Against.InvalidFormat(value, nameof(value), Pattern);
        }

        public string Value { get; }

    }
}
