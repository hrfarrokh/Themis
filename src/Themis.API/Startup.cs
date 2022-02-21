using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using Themis.Application;
using Themis.Core.LhsBracket.Abstractions;
using Themis.Core.LhsBracket.ModelBinder;
using Themis.Infrastructure;

namespace Themis.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure();

            services.AddControllers(options =>
            {
                options.ModelBinderProviders.Insert(0, new FilterModelBinderProvider());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Themis API", Version = "v1" });
                c.EnableAnnotations();
                c.DescribeAllParametersInCamelCase();
                c.MapType(typeof(FilterOperations<>), () => new OpenApiSchema { Type = "string" });
            });

            services.AddAutoMapper(typeof(ExhibitionOrderMappingProfile).Assembly);

            services.AddMediatR(typeof(PlaceOrderMetadataHandler).Assembly);

            services.AddValidatorsFromAssemblies(
                new[]
                {
                    typeof(PlaceExhibitionOrderRequestValidator).Assembly
                }
            );

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
