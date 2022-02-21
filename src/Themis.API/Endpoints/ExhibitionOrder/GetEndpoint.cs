using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Themis.Application;
using MediatR;

namespace Themis.API
{
    public class GetEndpoint : EndpointBaseAsync
        .WithRequest<ExhibitionOrderGetQuery>
        .WithResult<OrderDto>
    {
        private readonly IMediator _mediator;

        public GetEndpoint(IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator);
        }

        [HttpGet(ExhibitionOrderGetQuery.Route)]
        [SwaggerOperation(
            Summary = "Get an exhibition order by Id",
            OperationId = "GetExhibitionOrderById")
        ]
        public override async Task<OrderDto> HandleAsync(
              [FromRoute] ExhibitionOrderGetQuery request,
              CancellationToken ct)
        {
            Guard.Against.Null(request);

            return await _mediator.Send(request, ct);
        }

    }
}
