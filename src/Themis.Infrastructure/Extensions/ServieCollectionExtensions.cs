using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Themis.Application;
using Themis.Domain;
using Themis.Infrastructure.Persistance;
using Themis.Infrastructure.Services;

namespace Themis.Infrastructure
{
    public static class ServieCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DefaultTransactionPipline<,>));

            services.AddScoped<IUnitOfWorkManager, EFUnitOfWorkManager>();
            services.AddScoped<IOrderRepository, OrderRepository>()
                    .AddScoped<IOrderMetadataRepository, OrderMetadataRepository>();

            services.AddScoped<IRequestContextService, DefaultRequestContextService>();

            services.AddSingleton<IPackageService, InMemoryPackageService>()
                    .AddSingleton<IInventoryService, InMemoryInventoryService>()
                    .AddSingleton<ILookupService, InMemoryLookupService>();

            return services
                .AddDbContext<OrderDbContext>((sp, o) =>
                {
                    var isProduction = sp.GetRequiredService<IWebHostEnvironment>()
                                        .IsProduction();

                    var connectionString = sp.GetRequiredService<IConfiguration>()
                                            .GetConnectionString(OrderDbContext.ConnectionStringKey);

                    o.UseSqlServer(connectionString, ob => ob.MigrationsHistoryTable("__EFMigrationsHistory",
                                                                                    "ord"))
                    .EnableDetailedErrors(!isProduction)
                    .EnableSensitiveDataLogging(!isProduction)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

                })
                .AddScoped<IQueryRepository>(sp => sp.GetRequiredService<OrderDbContext>());
        }
    }
}
