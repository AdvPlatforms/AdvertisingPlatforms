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
        /// Get advertising platform by ID.
        /// </summary>
        /// <param name="id">ID of advertising platform.</param>
        /// <returns>Advertising platform or null.</returns>
        public Advertising? GetById(int id)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(GetById));
            var result = _advertisingPlatformPlatformsRepository.GetByIdFromRepository(id);

            _loggerService.LogEnd(this.GetType().Name, nameof(GetById));
            return result;
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Advertising> newEntitiesList)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(ReplaceRepository));
            
            _advertisingPlatformPlatformsRepository.ReplaceRepository(newEntitiesList);

            _loggerService.LogEnd(this.GetType().Name, nameof(ReplaceRepository));
            return newEntitiesList.Count;
        }
    }
}
