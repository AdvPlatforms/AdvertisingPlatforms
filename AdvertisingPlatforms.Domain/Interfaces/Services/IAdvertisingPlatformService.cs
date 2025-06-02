using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdvertisingPlatformService : IReplaceData<AdvertisingPlatform>
    {
        /// <summary>
        /// Get advertising platform names for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns>Advertising platform names.</returns>
        public IReadOnlyList<string>? GetAdvertisingPlatformsForLocation(string locationName);
    }
}
