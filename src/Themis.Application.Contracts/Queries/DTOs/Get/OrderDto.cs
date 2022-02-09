# nullable disable

namespace Themis.Application.Contracts
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string TrackingCode { get; set; }
        public string State { get; set; }
        public CustomerDto Customer { get; set; }
        public CityDto City { get; set; }
        public OrderItemDto Item { get; set; }
        public AuditDto Creation { get; set; }
        public AuditDto Modification { get; set; }
    }
}
