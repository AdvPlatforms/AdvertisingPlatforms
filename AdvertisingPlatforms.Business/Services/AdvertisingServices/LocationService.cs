using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service of locations.
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly Repository<Location> _locationRepository;

        public LocationService(Repository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        /// <summary>
        /// Get location by name.
        /// </summary>
        /// <param name="name">Name of location.</param>
        /// <returns>Location.</returns>
        public Location? GetByName(string name)
        {
            return _locationRepository.GetByNameFromRepository(name);
        }

        /// <summary>
        /// Get location by ID.
        /// </summary>
        /// <param name="id">ID of location.</param>
        /// <returns>Location.</returns>

        public Location? GetById(int id)
        {
            return _locationRepository.GetByIdFromRepository(id);
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Location> newEntitiesList)
        {
            _locationRepository.ReplaceRepository(newEntitiesList);

            return newEntitiesList.Count;
        }
    }
}
