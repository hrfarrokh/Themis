using Ardalis.GuardClauses;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Themis.Application.Contracts;
using Themis.Application.Contracts.Persistance;
using Themis.Domain;

namespace Themis.Application
{
    public class GetExhibitionOrderByIdHandler : IExhibitionOrderGetQueryHandler
    {
        private readonly IQueryRepository _repository;
        private readonly IMapper _mapper;

        public GetExhibitionOrderByIdHandler(IQueryRepository repository,
                                             IMapper mapper)
        {
            _repository = Guard.Against.Null(repository);
            _mapper = mapper;
        }

        public async Task<OrderDto> HandleAsync(
              ExhibitionOrderGetQuery request,
              CancellationToken ct)
        {
            Guard.Against.Null(request);
            Guard.Against.Default(request.Id, nameof(request.Id));

            var query = _repository.Query<OrderEntity>()
                                   .Where(e => e.Type == OrderType.Exhibition)
                                   .Where(e => e.Id == request.Id);

            var order = await _mapper.ProjectTo<OrderDto>(query)
                                     .FirstOrDefaultAsync(ct);

            if (order == null)
                throw new Exception("Entity Not Found.");


            return order;
        }
    }
}
