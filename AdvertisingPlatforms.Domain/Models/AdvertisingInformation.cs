namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// The type contains advertising and locations obtained from the file.
    /// </summary>
    public class AdvertisingInformation
    {
        /// <summary>
        /// Collection advertisingInLocations.
        /// </summary>
        public IReadOnlyList<AdvertisingPlatform> AdvertisingPlatforms { get; }

        /// <summary>
        /// Collection advertising.
        /// </summary>
        public IReadOnlyList<Advertising> Advertising { get; }

        /// <summary>
        /// Collection locations.
        /// </summary>
        public IReadOnlyList<Location> Locations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="advertisingPlatforms">Collection AdvertisingInLocation</param>
        /// <param name="advertising">Collection advertising.</param>
        /// <param name="locations">Collection locations.</param>
        public AdvertisingInformation( 
            IReadOnlyList<AdvertisingPlatform> advertisingPlatforms, 
            IReadOnlyList<Advertising> advertising, 
            IReadOnlyList<Location> locations)
        {
            AdvertisingPlatforms = advertisingPlatforms;
            Advertising = advertising;
            Locations = locations;
        }
    }
}
