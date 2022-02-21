namespace Themis.Application
{
    public class OrderMetadataGeneratedEvent
    {
        public Guid OrderId { get; set; }
        public string? Source { get; set; }
        public string? Campaign { get; set; }
        public string? PrevUrl { get; set; }
        public string? OrderPageUrl { get; set; }
        public string? PrevDomainUrl { get; set; }
        public string? Referrer { get; set; }
        public string? LandingPageUrl { get; set; }
    }
}
