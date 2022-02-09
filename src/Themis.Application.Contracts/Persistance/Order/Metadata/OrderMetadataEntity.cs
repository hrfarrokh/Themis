#nullable disable

using Themis.Domain;

namespace Themis.Application.Contracts.Persistance
{
    public class OrderMetadataEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public OrderChannel Channel { get; set; }
        public OrderOrigin Origin { get; set; }
        public OrderSource Source { get; set; }
        public string Campaign { get; set; }
        public string PrevUrl { get; set; }
        public string OrderPageUrl { get; set; }
        public string PrevDomainUrl { get; set; }
        public string Referrer { get; set; }
        public string LandingPageUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
