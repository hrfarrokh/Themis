using Ardalis.GuardClauses;

namespace Themis.Domain
{
    public class TenDigitTrackingCodePolicy : ITrackingCodeGenrationPolicy
    {
        private readonly ThreadLocal<Random> _random = new(() => new Random(Guid.NewGuid().GetHashCode()));

        public string Next()
        {
            var size = 10;

            string inputPart1 = "123456789";
            var chars1 = Enumerable.Range(1, size - 1)
                                   .Select(x => inputPart1[_random.Value!.Next(1, inputPart1.Length)]);

            string inputPart2 = "0123456789";
            var chars2 = Enumerable.Range(0, 1)
                                   .Select(x => inputPart2[_random.Value!.Next(0, inputPart2.Length)]);

            return new string(chars1.ToArray()) + new string(chars2.ToArray());
        }

        public string Verify(string value)
        {
            return Guard.Against.InvalidFormat(value, nameof(value), @"^([1-9]\d{9})$");
        }
    }
}
