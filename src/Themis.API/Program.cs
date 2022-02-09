using Serilog;
using MicrosoftHost = Microsoft.Extensions.Hosting.Host;

namespace Themis.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                                   .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return MicrosoftHost.CreateDefaultBuilder()
                .UseSerilog()
                .UseDefaultServiceProvider((context, options) =>
                {
                    var isDev = context.HostingEnvironment.IsDevelopment();

                    options.ValidateOnBuild = isDev;
                    options.ValidateScopes = isDev;
                })
                .ConfigureServices((hostContext, services) =>
                {
                    Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(hostContext.Configuration)
                                .CreateLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
