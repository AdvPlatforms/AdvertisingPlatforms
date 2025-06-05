using AdvertisingPlatforms.Business.ServiceCollection;
using AdvertisingPlatforms.DAL.Const;
using Microsoft.AspNetCore.Builder;
using Serilog;


namespace AdvertisingPlatforms.WebAppExtensions
{
    /// <summary>
    /// Extensions for web application builder.
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Configure web application builder(Business).
        /// </summary>
        /// <param name="builder">Builder.</param>
        public static void ConfigureBusiness(this WebApplicationBuilder builder) 
        {
            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    path: Path.Combine(AppContext.BaseDirectory, LoggerConstants.FilePath),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: LoggerConstants.OutputTemplate
                ));

            builder.Services.AddAdvertisingServices();
            builder.Services.AddFileServices();
            builder.Services.AddLogServices();
        }
    }
}
