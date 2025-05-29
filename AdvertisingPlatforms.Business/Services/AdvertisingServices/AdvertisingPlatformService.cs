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

        public AdvertisingPlatformService(
            Repository<AdvertisingPlatform> advertisingPlatformRepository,
            IAdvertisingService advertisingService,
            ILocationService locationService)
        {
            _advertisingPlatformRepository = advertisingPlatformRepository;
            _advertisingService = advertisingService;
            _locationService = locationService;
        }

        /// <summary>
        /// Get advertising platform names for location.
        /// </summary>
        /// <param name="locationName">Name of location.</param>
        /// <returns>Advertising platform names.</returns>
        /// <exception cref="GetAdvertisingException"></exception>
        public IReadOnlyList<string>? GetAdvertisingPlatformsForLocation(string locationName)
        {
            var locationId = _locationService.GetByName(locationName)?.Id 
                ?? throw new GetAdvertisingException(ErrorConstants.NotFound);

            var advertisingPlatform = _advertisingPlatformRepository.GetByIdFromRepository(locationId);

            return advertisingPlatform?.AdvertisingIds
                .Select(x => _advertisingService.GetById(x).Name)
                .ToList();
        }

        public int ReplaceRepository(IReadOnlyList<AdvertisingPlatform> newEntitiesList)
        {
            _advertisingPlatformRepository.ReplaceRepository(newEntitiesList);
            return newEntitiesList.Count;
        }
    }
}
