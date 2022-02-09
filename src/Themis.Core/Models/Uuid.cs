using Ardalis.GuardClauses;

namespace Themis.Core.Models
{
    public class Uuid : Id
    {
        private static IGuidGenerator s_generator = new GuidGenerator();

        public static IGuidGenerator GuidGenerator
        {
            get => s_generator;
            set => s_generator = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Uuid()
        {
            Value = GuidGenerator.Generate();
        }

        public Uuid(Guid value)
        {
            Value = Guard.Against.Default(value, nameof(value));
        }

        public Guid Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
