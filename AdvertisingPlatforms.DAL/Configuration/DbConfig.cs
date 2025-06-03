using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace AdvertisingPlatforms.DAL.Configuration
{
    /// <summary>
    /// Class provides access to the configuration file parameter.
    /// </summary>
    public static class DbConfig
    {
        private static Lazy<string> _advertisingPlatformDbPath;
        private static Lazy<string> _advertisingDbPath;
        private static Lazy<string> _locationDbPath;
        private static Lazy<string> _connectionString;

        private static bool _initialized = false;

        /// <summary>
        /// Path for database AdvertisingInLocation.
        /// </summary>
        public static string AdvertisingPlatformDbPath => _initialized
            ? _advertisingPlatformDbPath.Value
            : Error(ErrorConstants.ConfigNotInitialized);

        /// <summary>
        /// Path for database Advertising.
        /// </summary>
        public static string AdvertisingDbPath =>  _initialized
            ? _advertisingDbPath.Value 
            : Error(ErrorConstants.ConfigNotInitialized);

        /// <summary>
        /// Path for database Locations.
        /// </summary>
        public static string LocationDbPath => _initialized 
            ? _locationDbPath.Value 
            : Error(ErrorConstants.ConfigNotInitialized);

        /// <summary>
        /// Connection string for Sql-database.
        /// </summary>
        public static string ConnectionString => _initialized
            ? _connectionString.Value
            : Error(ErrorConstants.ConfigNotInitialized);

        /// <summary>
        /// Initialize configuration.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public static void Initialize(IConfiguration configuration)
        {
            if (_initialized) return;

            _advertisingPlatformDbPath = new Lazy<string>(() =>
                configuration.GetSection("FileDataBases:AdvertisingPlatform").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _advertisingDbPath = new Lazy<string>(() =>
                configuration.GetSection("FileDataBases:Advertising").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _locationDbPath = new Lazy<string>(() =>
                configuration.GetSection("FileDataBases:Location").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _connectionString = new Lazy<string>(() =>
                configuration.GetSection("SqlDataBases:ConnectionStrings:Default").Value ??
                Error(ErrorConstants.ConfigurationRead));

            _initialized = true;
        }

        private static string Error(string message) => throw new ConfigurationReadException(message);
    }
}
