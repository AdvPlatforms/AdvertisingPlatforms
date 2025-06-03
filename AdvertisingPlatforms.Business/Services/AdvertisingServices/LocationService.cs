using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service of locations.
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepository;
        private readonly ILoggerService _loggerService;

        public LocationService(IRepository<Location> locationRepository, ILoggerService loggerService)
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
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetByName));
            var result = _locationRepository.GetByNameFromRepository(name);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Get location by ID.
        /// </summary>
        /// <param name="id">ID of location.</param>
        /// <returns>Location.</returns>

        public Location? GetById(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetById));
            var result = _locationRepository.GetByIdFromRepository(id);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <returns>Collection locations or null.</returns>
        public IEnumerable<Location>? GetAll()
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAll));
            var result = _locationRepository.GetAllFromRepository();

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Delete location.
        /// </summary>
        /// <param name="id">Id for location.</param>
        public void Delete(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Delete));
            _locationRepository.DeleteFromRepository(id);

            _loggerService.LogEnd(logId);
        }

        /// <summary>
        /// Update location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void Update(Location location)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Update));
            _locationRepository.UpdateInRepository(location);

            _loggerService.LogEnd(logId);
        }

        /// <summary>
        /// Add location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void Add(Location location)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Add));
            _locationRepository.AddToRepository(location);

            _loggerService.LogEnd(logId);
        }


        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Location> newEntitiesList)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(ReplaceRepository));
            _locationRepository.ReplaceRepository(newEntitiesList);

            _loggerService.LogEnd(logId);
            return newEntitiesList.Count;
        }
    }
}
