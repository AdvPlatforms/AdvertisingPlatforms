using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Business.Services.AdvertisingServices;
using AdvertisingPlatforms.Business.Services.FileHandlingServices;
using Microsoft.Extensions.DependencyInjection;
using AdvertisingPlatforms.Business.Services;

namespace AdvertisingPlatforms.Business.ServiceCollection
{
    /// <summary>
    /// Extensions for service collection.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration advertising services
        /// </summary>
        public static void AddAdvertisingServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisingService, AdvertisingService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IAdvertisingPlatformService, AdvertisingPlatformService>();
        }

        /// <summary>
        /// Method for registration file services
        /// </summary>
        public static void AddFileServices(this IServiceCollection services)
        {
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IFileParser, FileParser>();
            services.AddScoped<IFileValidator, FileValidator>();
        }

        /// <summary>
        /// Method for registration log services
        /// </summary>
        public static void AddLogServices(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, LoggerService>();
        }
    }
}
