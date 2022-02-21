using Microsoft.EntityFrameworkCore;
using Themis.Application;
using Themis.Core.Models;
using Themis.Domain;

namespace Themis.Infrastructure.Persistance
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<(OrderType, OrderState), IOrderEntityMapper> _mapperRegistry =
            new()
            {
                { (OrderType.Exhibition, ExhibitionOrderState.New), new NewExhibitionOrderMapper() }
            };
        private readonly OrderDbContext _dbContext;
        private readonly IRequestContextService _requestContextService;

        public OrderRepository(OrderDbContext dbContext,
                               IRequestContextService requestContextService)
        {
            _dbContext = dbContext;
            _requestContextService = requestContextService;
        }

        public async Task CreateAsync(Order aggregate, CancellationToken ct = default)
        {
            IOrderEntityMapper mapper = _mapperRegistry[(aggregate.Type, aggregate.State)];

            var context = new OrderEntityMapperContext(_dbContext,
                                                       aggregate,
                                                       _requestContextService.GetUserId(),
                                                       _requestContextService.GetUsername());

            mapper.ToEntity(context);

            try
            {
                await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Task<Order> FindByIdAsync(Uuid id, CancellationToken ct = default) => throw new NotImplementedException();

    }
}
