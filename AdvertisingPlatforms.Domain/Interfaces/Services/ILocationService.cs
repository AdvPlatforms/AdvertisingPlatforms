using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for managing locations.
    /// </summary>
    public interface ILocationService: IReplaceData<Location>
    {
        /// <summary>
        /// Get id location by name.
        /// </summary>
        /// <param name="name">Name of location.</param>
        /// <returns>Return location or null.</returns>
        public Location? GetByName(string name);

        /// <summary>
        /// Get location by ID.
        /// </summary>
        /// <param name="id">ID of location.</param>
        /// <returns>Location.</returns>
        public Location? GetById(int id);

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <returns>Collection locations or null.</returns>
        public IEnumerable<Location>? GetAll();

        /// <summary>
        /// Delete location.
        /// </summary>
        /// <param name="id">Id for location.</param>
        public void Delete(int id);

        /// <summary>
        /// Update location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void Update(Location location);

        /// <summary>
        /// Add location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void Add(Location location);
    }
}
