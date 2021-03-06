#nullable disable

namespace Themis.Application.Persistance
{
    public class OrderItemEntity
    {
        public InventoryItemEntity InventoryItem { get; set; }
        public PackageEntity Package { get; set; }
        public AppointmentEntity Appointment { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
