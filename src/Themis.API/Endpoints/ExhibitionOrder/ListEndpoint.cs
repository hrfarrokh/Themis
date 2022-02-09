using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Themis.Application.Contracts;

namespace Themis.API
{
    public class ListEndpoint : EndpointBaseAsync
        .WithRequest<ExhibitionOrderListQuery>
        .WithResult<ListResponse<OrderListDto>>
    {
        private readonly IExhibitionOrderListQueryHandler _handler;

        public ListEndpoint(IExhibitionOrderListQueryHandler handler)
        {
            _handler = Guard.Against.Null(handler);
        }

        [HttpGet(ExhibitionOrderListQuery.Route)]
        [SwaggerOperation(
            Summary = "List exhibition orders",
            OperationId = "ListExhibitionOrder")
        ]
        public override async Task<ListResponse<OrderListDto>> HandleAsync(
              [FromQuery] ExhibitionOrderListQuery request,
              CancellationToken ct)
        {
            Guard.Against.Null(request);

            return await _handler.HandleAsync(request, ct);
        }

    }
}
