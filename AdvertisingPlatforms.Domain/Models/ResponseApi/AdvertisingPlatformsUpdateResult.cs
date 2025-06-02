using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Information about the number of updated entities.
    /// </summary>
    public class AdvertisingPlatformsUpdateResult: BaseResponse
    {
        /// <summary>
        /// Count of adds advertising platforms.
        /// </summary>
        public int CountAdvertisingPlatforms { get; }

        /// <summary>
        /// Count of adds locations.
        /// </summary>
        public int CountLocations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="countAdvertisingPlatforms">Count of adds advertising platforms.</param>
        /// <param name="countLocations">Count of adds locations.</param>
        public AdvertisingPlatformsUpdateResult(int countAdvertisingPlatforms, int countLocations) : base(true)
        {
            CountAdvertisingPlatforms = countAdvertisingPlatforms;
            CountLocations = countLocations;
        }
    }
}
