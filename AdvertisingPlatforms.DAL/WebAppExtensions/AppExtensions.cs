using AdvertisingPlatforms.DAL.Configuration;
using Microsoft.AspNetCore.Builder;

namespace AdvertisingPlatforms.DAL.WebAppExtensions
{
    /// <summary>
    /// Extensions for web application.
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Configure web application(DAL).
        /// </summary>
        /// <param name="app">Web application.</param>
        public static void ConfigureDal(this WebApplication app)
        {
            DbConfig.Initialize(app.Configuration); 
        }
    }
}
