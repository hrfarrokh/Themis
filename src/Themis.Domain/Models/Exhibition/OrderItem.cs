
using System.Collections;
using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class OrderItem : ValueObject<OrderItem>
    {
        private Package _package;
        private Appointment _appointment;
        private InventoryItem _inventoryItem;

        public OrderItem(Package package,
                         Appointment appointment,
                         InventoryItem inventoryItem)
        {
            _package = Guard.Against.Null(package);
            _appointment = Guard.Against.Null(appointment);
            _inventoryItem = Guard.Against.Null(inventoryItem);
        }

        public Package Package => _package;
        public Appointment Appointment => _appointment;
        public InventoryItem InventoryItem => _inventoryItem;
        public Money TotalAmount => _inventoryItem.Price.Add(Package.Price);
    }
}
