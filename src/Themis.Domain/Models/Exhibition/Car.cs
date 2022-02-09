using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class Car : ValueObject<Car>
    {
        public Car(int id,
                   string type,
                   string generation,
                   string brand,
                   string model,
                   string color,
                   int year)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Type = Guard.Against.NullOrWhiteSpace(type, nameof(type));
            Generation = Guard.Against.NullOrWhiteSpace(generation, nameof(generation));
            Brand = Guard.Against.NullOrWhiteSpace(brand, nameof(brand));
            Model = Guard.Against.NullOrWhiteSpace(model, nameof(model));
            Color = Guard.Against.NullOrWhiteSpace(color, nameof(color));
            Year = Guard.Against.NegativeOrZero(year, nameof(year));
        }

        public int Id { get; }
        public string Type { get; }
        public string Generation { get; }
        public string Brand { get; }
        public string Model { get; }
        public string Color { get; }
        public int Year { get; }

    }
}
