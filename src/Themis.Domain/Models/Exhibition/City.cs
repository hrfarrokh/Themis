using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class City : ValueObject<City>
    {
        public City(int id, string title, string district)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            District = Guard.Against.NullOrWhiteSpace(district, nameof(district));
        }

        public int Id { get; }
        public string Title { get; }
        public string District { get; }

    }
}
