using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class InventoryItem : ValueObject<InventoryItem>
    {
        public InventoryItem(InventoryItemId inventoryItemId,
                             FullName fullName,
                             Car car,
                             City city,
                             Mileage mileage,
                             Money price)
        {
            InventoryItemId = Guard.Against.Null(inventoryItemId);
            FullName = Guard.Against.Null(fullName);
            Car = Guard.Against.Null(car);
            City = Guard.Against.Null(city);
            Mileage = Guard.Against.Null(mileage);
            Price = Guard.Against.Null(price);
        }

        public InventoryItemId InventoryItemId { get; }
        public FullName FullName { get; }
        public Car Car { get; }
        public City City { get; }
        public Mileage Mileage { get; }
        public Money Price { get; }
    }
}
