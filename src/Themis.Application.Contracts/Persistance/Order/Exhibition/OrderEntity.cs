#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid Key => Id;
        public string TrackingCode { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string StateCategory { get; set; }
        public CustomerEntity Customer { get; set; }
        public CityEntity City { get; set; }
        public OrderItemEntity Item { get; set; }

        public AuditEntity Creation { get; set; }
        public AuditEntity Modification { get; set; }
        public byte[] Version { get; set; }
    }
}
