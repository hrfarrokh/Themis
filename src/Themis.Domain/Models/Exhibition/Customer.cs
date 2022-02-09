using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class Customer : ValueObject<Customer>
    {
        public Customer(Guid userId,
                       string fullName,
                       string phoneNumber)
        {
            Id = new Uuid(userId);
            FullName = new FullName(fullName);
            PhoneNumber = new PhoneNumber(Guard.Against.Null(phoneNumber));
        }

        public Uuid Id { get; }
        public FullName FullName { get; }
        public PhoneNumber PhoneNumber { get; }

    }
}
