using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{
    public class OrderMetadata : AggregateBase<OrderMetadata, Uuid>
    {
        public OrderMetadata(Guid orderId,
                             OrderChannel channel,
                             OrderOrigin origin,
                             OrderSource source,
                             string? campaign,
                             string? prevUrl,
                             string? orderPageUrl,
                             string? prevDomainUrl,
                             string? referrer)
            : base(new Uuid())
        {
            OrderId = Guard.Against.Default(orderId, nameof(orderId));
            Channel = Guard.Against.EnumOutOfRange(channel, nameof(channel));
            Origin = Guard.Against.EnumOutOfRange(origin, nameof(origin));
            Source = Guard.Against.EnumOutOfRange(source, nameof(source));
            Campaign = campaign;
            PrevUrl = prevUrl;
            OrderPageUrl = orderPageUrl;
            PrevDomainUrl = prevDomainUrl;
            Referrer = referrer;
        }

        public Guid OrderId { get; set; }
        public OrderChannel Channel { get; set; }
        public OrderOrigin Origin { get; set; }
        public OrderSource Source { get; set; }
        public string? Campaign { get; set; }
        public string? PrevUrl { get; set; }
        public string? OrderPageUrl { get; set; }
        public string? PrevDomainUrl { get; set; }
        public string? Referrer { get; set; }
        public string? LandingPageUrl { get; set; }
    }
}
