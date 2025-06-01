using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for service of platforms.
    /// </summary>
    public interface IAdvertisingService: IReplaceData<Advertising>
    {
        /// <summary>
        /// Get all advertising by IDs.
        /// </summary>
        /// <param name="advertisingIds">ID of advertising platform.</param>
        /// <returns>List of advertising or null.</returns>
        /// <exception cref="GetAdvertisingException"></exception>
        public List<Advertising>? GetAllByIds(IEnumerable<int> advertisingIds);
    }
}
