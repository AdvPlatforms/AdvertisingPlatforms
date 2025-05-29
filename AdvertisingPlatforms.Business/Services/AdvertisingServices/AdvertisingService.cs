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

        public AdvertisingService(Repository<Advertising> advertisingPlatformsRepository)
        {
            _advertisingPlatformPlatformsRepository = advertisingPlatformsRepository;
        }

        /// <summary>
        /// Get advertising platform by ID.
        /// </summary>
        /// <param name="id">ID of advertising platform.</param>
        /// <returns>Advertising platform or null.</returns>
        public Advertising? GetById(int id)
        {
            return _advertisingPlatformPlatformsRepository.GetByIdFromRepository(id);
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Advertising> newEntitiesList)
        {
            _advertisingPlatformPlatformsRepository.ReplaceRepository(newEntitiesList);

            return newEntitiesList.Count;
        }
    }
}
