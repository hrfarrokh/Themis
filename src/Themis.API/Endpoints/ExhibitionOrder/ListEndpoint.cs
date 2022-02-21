using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Themis.Application;

namespace Themis.API
{
    public class ListEndpoint : EndpointBaseAsync
        .WithRequest<ExhibitionOrderListQuery>
        .WithResult<ListResponse<OrderListDto>>
    {
        private readonly IMediator _mediator;

        public ListEndpoint(IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator);
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

            return await _mediator.Send(request, ct);
        }

    }
}
