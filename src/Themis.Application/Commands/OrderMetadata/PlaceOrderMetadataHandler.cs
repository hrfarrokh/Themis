using Ardalis.GuardClauses;
using MediatR;
using Themis.Core.Extensions;
using Themis.Domain;

namespace Themis.Application
{
    public class PlaceOrderMetadataHandler : AsyncRequestHandler<PlaceOrderMetadataRequest>
    {
        private readonly IOrderMetadataRepository _repository;

        public PlaceOrderMetadataHandler(IOrderMetadataRepository repository)
        {
            _repository = Guard.Against.Null(repository);
        }

        protected override async Task Handle(
            PlaceOrderMetadataRequest request,
            CancellationToken ct)
        {
            Guard.Against.Null(request);

            var campaign = ResolveCampaign(request.Campaign, request.LandingPageUrl);
            var channel = request.Source.ToEnum(OrderChannel.Unknown);
            var origin = ResolveOrigin(channel);
            var source = ResolveSource(channel, request.PrevDomainUrl, campaign);

            var orderMetadata = new OrderMetadata(request.OrderId,
                                                  channel,
                                                  origin,
                                                  source,
                                                  campaign,
                                                  request.PrevUrl,
                                                  request.OrderPageUrl,
                                                  request.PrevDomainUrl,
                                                  request.Referrer);

            await _repository.CreateAsync(orderMetadata, ct);
        }

        private OrderSource ResolveSource(OrderChannel channel,
                                          string? prevDomainUrl,
                                          string? campaign)
        {
            if (channel == OrderChannel.Web)
            {
                if (string.IsNullOrEmpty(prevDomainUrl))
                    return OrderSource.Direct;

                if (prevDomainUrl.Contains("google"))
                    return OrderSource.Organic;

                if (!string.IsNullOrEmpty(campaign))
                    return OrderSource.Campaign;
            }

            if (channel == OrderChannel.IOS)
                return OrderSource.IosApp;

            if (channel == OrderChannel.Android)
                return OrderSource.AndroidApp;

            return OrderSource.Unknown;
        }

        private OrderOrigin ResolveOrigin(OrderChannel channel)
        {
            if (channel == OrderChannel.Web)
                return OrderOrigin.WebSite;

            if (channel == OrderChannel.IOS || channel == OrderChannel.Android)
                return OrderOrigin.MobileApp;

            return OrderOrigin.Unknown;
        }

        private string? ResolveCampaign(string? code, string? landingPageUrl)
        {
            if (!string.IsNullOrWhiteSpace(code))
                return code;

            if (!string.IsNullOrWhiteSpace(landingPageUrl))
            {
                if (landingPageUrl.Contains("car-sell/campaign")
                   || landingPageUrl.Contains("car-buy/campaign"))
                {
                    var urlLength = landingPageUrl.Split("/").Length;
                    if (urlLength > 1)
                    {
                        var newCode = landingPageUrl.Split("/")[urlLength - 2];

                        if (!string.IsNullOrWhiteSpace(newCode))
                            return newCode;
                    }
                }
            }

            return null;
        }

    }
}
