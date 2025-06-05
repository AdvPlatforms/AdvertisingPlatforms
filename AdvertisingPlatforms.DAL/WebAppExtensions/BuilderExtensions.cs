using AdvertisingPlatforms.DAL.Configuration;
using AdvertisingPlatforms.DAL.ServiceCollection;
using Microsoft.AspNetCore.Builder;


namespace AdvertisingPlatforms.WebAppExtensions
{
    /// <summary>
    /// Extensions for web application builder.
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Configure web application builder(Dal).
        /// </summary>
        /// <param name="builder">Builder.</param>
        public static void ConfigureBuilderDal(this WebApplicationBuilder builder) 
        {
            DbConfig.Initialize(builder.Configuration);

            builder.Services.AddRepositoryServices();
        }
    }
}
