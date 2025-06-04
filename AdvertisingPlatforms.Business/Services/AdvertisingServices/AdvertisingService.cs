using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Business.Services.AdvertisingServices
{

    /// <summary>
    /// Service for advertising platforms.
    /// </summary>
    public class AdvertisingService : IAdvertisingService
    {
        private readonly IRepository<Advertising> _advertisingRepository;
        private readonly ILoggerService _loggerService;

        public AdvertisingService(IRepository<Advertising> advertisingRepository,
            ILoggerService loggerService)
        {
            _advertisingRepository = advertisingRepository;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get advertising by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Advertising or null.</returns>
        public Advertising? GetById(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetById));
            var result = _advertisingRepository.GetByIdFromRepository(id);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Get all advertising.
        /// </summary>
        /// <returns>Advertising collection or null.</returns>
        public IEnumerable<Advertising>? GetAll()
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAll));
            var result = _advertisingRepository.GetAllFromRepository();

            _loggerService.LogEnd(logId);
            return result;       
        }

        /// <summary>
        /// Get all advertising by IDs.
        /// </summary>
        /// <param name="advertisingIds">ID of advertising platform.</param>
        /// <returns>List of advertising or null.</returns>
        public List<Advertising>? GetAllByIds(IEnumerable<int> advertisingIds)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAllByIds));
            var result = _advertisingRepository.GetByIdFromRepository(advertisingIds);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Add advertising.
        /// </summary>
        /// <param name="advertising"></param>
        public void Add(Advertising advertising)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Add));
            _advertisingRepository.AddToRepository(advertising);

            _loggerService.LogEnd(logId);         
        }

        /// <summary>
        /// Delete advertising.
        /// </summary>
        /// <param name="id">Id for advertising.</param>
        public void Delete(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Delete));
            _advertisingRepository.DeleteFromRepository(id);

            _loggerService.LogEnd(logId);       
        }

        /// <summary>
        /// Update advertising.
        /// </summary>
        /// <param name="id">Id for advertising.</param>

        public void Update(Advertising advertising)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Update));
            _advertisingRepository.UpdateInRepository(advertising);

            _loggerService.LogEnd(logId);           
        }

        /// <summary>
        /// Replace data of repository.
        /// </summary>
        /// <param name="newEntitiesList">New data for repository.</param>
        /// <returns>Count new entities.</returns>
        public int ReplaceRepository(IReadOnlyList<Advertising> newEntitiesList)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(ReplaceRepository));
            
            _advertisingRepository.ReplaceRepository(newEntitiesList);

            _loggerService.LogEnd(logId);
            return newEntitiesList.Count;
        }
    }
}
