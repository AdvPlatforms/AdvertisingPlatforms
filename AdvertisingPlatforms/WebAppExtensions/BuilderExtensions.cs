using AdvertisingPlatforms.ServiceCollection;

namespace AdvertisingPlatforms.WebAppExtensions
{
    /// <summary>
    /// Extensions for web application builder.
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Configure web application builder.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public static void ConfigureBuilder(this WebApplicationBuilder builder) 
        {
            builder.Services.AddWebServices();

            builder.ConfigureBuilderDal();               
            builder.ConfigureBusiness();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddSwaggerServices();
            }
        }
    }
}
