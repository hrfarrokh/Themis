
using Ardalis.GuardClauses;

namespace Themis.Core.Models
{
    public class Version : ValueObject<Version>
    {
        public static Version Zero => new Version(Array.Empty<byte>());

        public Version(byte[] version)
        {
            Value = Guard.Against.Null(version, nameof(version));
        }

        public byte[] Value { get; }

    }
}
