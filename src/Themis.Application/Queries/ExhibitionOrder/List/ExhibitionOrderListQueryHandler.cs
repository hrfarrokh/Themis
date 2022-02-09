using Ardalis.GuardClauses;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Themis.Application.Contracts;
using Themis.Application.Contracts.Persistance;
using Themis.Domain;

namespace Themis.Application
{
    public class ExhibitionOrderListQueryHandler : IExhibitionOrderListQueryHandler
    {
        private readonly IQueryRepository _repository;
        private readonly IMapper _mapper;

        public ExhibitionOrderListQueryHandler(IQueryRepository repository,
                                               IMapper mapper)
        {
            _repository = Guard.Against.Null(repository);
            _mapper = mapper;
        }

        public async Task<ListResponse<OrderListDto>> HandleAsync(
            ExhibitionOrderListQuery request,
            CancellationToken ct)
        {
            Guard.Against.Null(request);
            Guard.Against.Default(request.Take, nameof(request.Take));

            int? totalCount = null;
            Guid? cursor = null;

            var orders = _repository.Query<OrderEntity>()
                                    .Where(e => e.Type == OrderType.Exhibition);

            if (request.TotalCount)
                totalCount = await orders.CountAsync(ct);

            if (request.Cursor.HasValue)
                orders = orders.Where(e => e.Id.CompareTo(request.Cursor.Value) > 0);

            var items = await _mapper.ProjectTo<OrderListDto>(orders.Take(request.Take + 1))
                                     .ToListAsync(ct);

            if (items.Count == request.Take + 1)
                cursor = items.Last().Key;

            return new ListResponse<OrderListDto>(items, totalCount, cursor);
        }
    }
}
