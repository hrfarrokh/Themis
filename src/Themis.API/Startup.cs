using FluentValidation;
using Microsoft.OpenApi.Models;
using Themis.Application;
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Themis API", Version = "v1" });
                c.EnableAnnotations();
                c.DescribeAllParametersInCamelCase();
            });

            services.AddAutoMapper(typeof(ExhibitionOrderMappingProfile).Assembly);

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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
