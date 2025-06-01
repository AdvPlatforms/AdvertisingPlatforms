using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{

    /// <summary>
    /// Service for advertising platforms.
    /// </summary>
    public class AdvertisingService : IAdvertisingService
    {
        private readonly Repository<Advertising> _advertisingPlatformPlatformsRepository;
        private readonly ILoggerService _loggerService;

        public AdvertisingService(Repository<Advertising> advertisingPlatformsRepository,
            ILoggerService loggerService)
        {
            _advertisingPlatformPlatformsRepository = advertisingPlatformsRepository;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get all advertising by IDs.
        /// </summary>
        /// <param name="advertisingIds">ID of advertising platform.</param>
        /// <returns>List of advertising or null.</returns>
        public List<Advertising>? GetAllByIds(IEnumerable<int> advertisingIds)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAllByIds));
            var result = _advertisingPlatformPlatformsRepository.GetByIdFromRepository(advertisingIds);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Advertising> newEntitiesList)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(ReplaceRepository));
            
            _advertisingPlatformPlatformsRepository.ReplaceRepository(newEntitiesList);

            _loggerService.LogEnd(logId);
            return newEntitiesList.Count;
        }
    }
}
