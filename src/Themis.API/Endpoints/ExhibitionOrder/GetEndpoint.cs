using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Themis.Application.Contracts;

namespace Themis.API
{
    public class GetEndpoint : EndpointBaseAsync
        .WithRequest<ExhibitionOrderGetQuery>
        .WithResult<OrderDto>
    {
        private readonly IExhibitionOrderGetQueryHandler _handler;

        public GetEndpoint(IExhibitionOrderGetQueryHandler handler)
        {
            _handler = Guard.Against.Null(handler);
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

            return await _handler.HandleAsync(request, ct);
        }

    }
}
