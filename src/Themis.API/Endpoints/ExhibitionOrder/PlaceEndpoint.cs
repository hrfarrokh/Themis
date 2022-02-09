using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Themis.Application.Contracts;

namespace Themis.API
{
    public class PlaceEndpoint : EndpointBaseAsync
        .WithRequest<PlaceExhibitionOrderRequest>
        .WithResult<PlaceExhibitionOrderResponse>
    {
        private readonly IPlaceExhibitionOrderHandler _handler;

        public PlaceEndpoint(IPlaceExhibitionOrderHandler handler)
        {
            _handler = Guard.Against.Null(handler);
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

            return await _handler.HandleAsync(request, ct);
        }
    }
}
