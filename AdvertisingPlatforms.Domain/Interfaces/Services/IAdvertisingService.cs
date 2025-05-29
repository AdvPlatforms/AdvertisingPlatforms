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
        /// Get advertising platform by ID.
        /// </summary>
        /// <param name="id">ID of advertising platform.</param>
        /// <returns>Advertising platform or null.</returns>
        /// <exception cref="GetAdvertisingException"></exception>
        public Advertising? GetById(int id);
    }
}
