# nullable disable

namespace Themis.Application
{
    public class OrderListDto
    {
        public Guid Key { get; set; }
        public string TrackingCode { get; set; }
        public string State { get; set; }
        public string Customer { get; set; }
        public string City { get; set; }
        public InventoryItemListDto InventoryItem { get; set; }
        public string Package { get; set; }
        public AppointmentDto Appointment { get; set; }

        public AuditDto Creation { get; set; }
        public AuditDto Modification { get; set; }
    }
}
