using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{
    /// <summary>
    /// Service for searching advertising platforms for a specific location.
    /// </summary>
    public class AdvertisingPlatformService : IAdvertisingPlatformService
    {
        private readonly Repository<AdvertisingPlatform> _advertisingPlatformRepository;
        private readonly IAdvertisingService _advertisingService;
        private readonly ILocationService _locationService;
        private readonly ILoggerService _loggerService;

        public AdvertisingPlatformService(
            Repository<AdvertisingPlatform> advertisingPlatformRepository,
            IAdvertisingService advertisingService,
            ILocationService locationService,
            ILoggerService loggerService)
        {
            _advertisingPlatformRepository = advertisingPlatformRepository;
            _advertisingService = advertisingService;
            _locationService = locationService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get advertising platform names for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns>Advertising platform names.</returns>
        /// <exception cref="GetAdvertisingException"></exception>
        public IReadOnlyList<string>? GetAdvertisingPlatformsForLocation(string locationName)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAdvertisingPlatformsForLocation));
            var locationId = _locationService.GetByName(locationName)?.Id 
                ?? throw new GetAdvertisingException(ErrorConstants.NotFound);

            var advertisingPlatform = _advertisingPlatformRepository.GetByIdFromRepository(locationId);

            var result = _advertisingService.GetAllByIds(advertisingPlatform?.AdvertisingIds)? 
                .Select(x => x.Name)
                .ToList();

            _loggerService.LogEnd(logId);
            return result;
        }

        public int ReplaceRepository(IReadOnlyList<AdvertisingPlatform> newEntitiesList)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(ReplaceRepository));

            _advertisingPlatformRepository.ReplaceRepository(newEntitiesList);

            _loggerService.LogEnd(logId);
            return newEntitiesList.Count;
        }
    }
}
