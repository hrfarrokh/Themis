# nullable disable

namespace Themis.Application.Contracts
{
    public class OrderItemDto
    {
        public InventoryItemDto InventoryItem { get; set; }
        public PackageDto Package { get; set; }
        public AppointmentDto Appointment { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
