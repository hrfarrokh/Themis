using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{

    public class TrackingCode : ValueObject<TrackingCode>
    {
        private readonly ITrackingCodeGenrationPolicy _policy = new TenDigitTrackingCodePolicy();

        private TrackingCode()
        {
            Value = _policy.Next();
        }

        private TrackingCode(string value)
        {
            Value = _policy.Verify(value);
        }

        public static TrackingCode Parse(string value)
        {
            return new TrackingCode(value);
        }

        public static TrackingCode New()
        {
            return new TrackingCode();
        }

        public string Value { get; }
    }
}
