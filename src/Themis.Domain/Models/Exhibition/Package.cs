using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class Package : ValueObject<Package>
    {
        public Package(int id, string title, Money price)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            Price = Guard.Against.Null(price);
        }

        public int Id { get; }
        public string Title { get; }
        public Money Price { get; }

    }
}
