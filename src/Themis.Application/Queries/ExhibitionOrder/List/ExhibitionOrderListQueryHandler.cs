using Ardalis.GuardClauses;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Themis.Application.Persistance;
using Themis.Core.LhsBracket.LinqExpression;
using Themis.Domain;

namespace Themis.Application
{
    public class ExhibitionOrderListQueryHandler
        : IRequestHandler<ExhibitionOrderListQuery, ListResponse<OrderListDto>>
    {
        private readonly IQueryRepository _repository;
        private readonly IMapper _mapper;

        public ExhibitionOrderListQueryHandler(IQueryRepository repository,
                                               IMapper mapper)
        {
            _repository = Guard.Against.Null(repository);
            _mapper = mapper;
        }

        public async Task<ListResponse<OrderListDto>> Handle(
            ExhibitionOrderListQuery request,
            CancellationToken ct)
        {
            Guard.Against.Null(request);
            Guard.Against.Default(request.Take, nameof(request.Take));

            int? totalCount = null;
            Guid? cursor = null;

            var orders = _repository.Query<OrderEntity>()
                                    .Where(e => e.Type == OrderType.Exhibition)
                                    .ApplyFilters(e => e.TrackingCode, request.TrackingCode)
                                    .ApplyFilters(e => e.Customer.PhoneNumber, request.PhoneNumber);

            if (request.TotalCount)
                totalCount = await orders.CountAsync(ct);

            if (request.Cursor.HasValue)
                orders = orders.Where(e => e.Id.CompareTo(request.Cursor.Value) > 0);

            var items = await _mapper.ProjectTo<OrderListDto>(orders.Take(request.Take))
                                     .ToListAsync(ct);

            if (items.Count == request.Take)
                cursor = items.Last().Key;

            return new ListResponse<OrderListDto>(items, totalCount, cursor);
        }
    }
}
