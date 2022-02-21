using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Themis.Application;

namespace Themis.API
{
    public class PlaceEndpoint : EndpointBaseAsync
        .WithRequest<PlaceExhibitionOrderRequest>
        .WithResult<PlaceExhibitionOrderResponse>
    {
        private readonly MediatR.IMediator _mediator;

        public PlaceEndpoint(MediatR.IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator);
        }

        [HttpPost(PlaceExhibitionOrderRequest.Route)]
        [SwaggerOperation(
            Summary = "Place a new exhibition order",
            OperationId = "PlaceExhibitionOrder")
        ]
        public override async Task<PlaceExhibitionOrderResponse> HandleAsync(
              [FromBody] PlaceExhibitionOrderRequest request,
              CancellationToken ct)
        {
            Guard.Against.Null(request);

            return await _mediator.Send(request, ct);
        }
    }
}
