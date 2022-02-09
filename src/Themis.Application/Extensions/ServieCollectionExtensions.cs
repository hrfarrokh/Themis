using Microsoft.Extensions.DependencyInjection;
using Themis.Application.Contracts;

namespace Themis.Application
{
    public static class ServieCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddScoped<IPlaceExhibitionOrderHandler, PlaceExhibitionOrderHandler>()
                           .AddScoped<IPlaceOrderMetadataHandler, PlaceOrderMetadataHandler>()
                           .AddScoped<IExhibitionOrderListQueryHandler, ExhibitionOrderListQueryHandler>()
                           .AddScoped<IExhibitionOrderGetQueryHandler, GetExhibitionOrderByIdHandler>();
        }
    }
}
