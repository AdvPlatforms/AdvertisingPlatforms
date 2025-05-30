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
        private readonly ILoggerService _loggerService;

        public LocationService(Repository<Location> locationRepository, ILoggerService loggerService)
        {
            _locationRepository = locationRepository;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get location by name.
        /// </summary>
        /// <param name="name">Name of location.</param>
        /// <returns>Location.</returns>
        public Location? GetByName(string name)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(GetByName));
            var result = _locationRepository.GetByNameFromRepository(name);

            _loggerService.LogEnd(this.GetType().Name, nameof(GetByName));
            return result;
        }

        /// <summary>
        /// Get location by ID.
        /// </summary>
        /// <param name="id">ID of location.</param>
        /// <returns>Location.</returns>

        public Location? GetById(int id)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(GetById));
            var result = _locationRepository.GetByIdFromRepository(id);

            _loggerService.LogEnd(this.GetType().Name, nameof(GetById));
            return result;
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Location> newEntitiesList)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(ReplaceRepository));
            _locationRepository.ReplaceRepository(newEntitiesList);

            _loggerService.LogEnd(this.GetType().Name, nameof(ReplaceRepository));
            return newEntitiesList.Count;
        }
    }
}
