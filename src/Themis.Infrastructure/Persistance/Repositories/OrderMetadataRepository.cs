using Themis.Application;
using Themis.Application.Persistance;
using Themis.Core;
using Themis.Domain;

namespace Themis.Infrastructure.Persistance
{
    public class OrderMetadataRepository : IOrderMetadataRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderMetadataRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(OrderMetadata aggregate, CancellationToken ct = default)
        {
            var entity = new OrderMetadataEntity
            {
                OrderId = aggregate.OrderId,
                Channel = aggregate.Channel,
                Origin = aggregate.Origin,
                Source = aggregate.Source,
                Campaign = aggregate.Campaign,
                PrevUrl = aggregate.PrevUrl,
                OrderPageUrl = aggregate.OrderPageUrl,
                PrevDomainUrl = aggregate.PrevDomainUrl,
                Referrer = aggregate.Referrer,
                LandingPageUrl = aggregate.LandingPageUrl,
                CreatedAt = Clock.Now
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync(ct);
        }

    }
}
