using Microsoft.Extensions.DependencyInjection;

namespace Themis.Application
{
    public static class ServieCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddScoped<PlaceExhibitionOrderHandler>()
                           .AddScoped<PlaceOrderMetadataHandler>()
                           .AddScoped<ExhibitionOrderListQueryHandler>()
                           .AddScoped<GetExhibitionOrderByIdHandler>();
        }
    }
}
