using AdvertisingPlatforms.DAL.Configuration;
using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileAccess;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories.Base
{
    /// <summary>
    /// Facade for work with FileRepository, RepositoryReader, RepositoryWriter.
    /// </summary>
    /// <typeparam name="TResource">Resource.</typeparam>
    public abstract class FileFacadeRepository<TResource> :IRepository<TResource> where TResource: Resource 
    {
        private readonly FileRepository<TResource> _fileRepository;
        private readonly IRepositoryReader _repositoryReader;
        private readonly IRepositoryWriter _repositoryWriter;
        private readonly ILoggerService _loggerService;
        public FileFacadeRepository(
            IRepositoryReader repositoryReader, 
            IRepositoryWriter repositoryWriter, 
            ILoggerService loggerService)
        {
            _repositoryReader = repositoryReader;
            _repositoryWriter = repositoryWriter;
            _loggerService = loggerService;

            var filePath = GetFilePath();
            _fileRepository = new FileRepository<TResource>(filePath);
        }

        private static string GetFilePath()
        {
            return typeof(TResource).Name switch
            {
                "Location" => DbConfig.LocationDbPath,
                "Advertising" => DbConfig.AdvertisingDbPath,
                "AdvertisingPlatform" => DbConfig.AdvertisingPlatformDbPath,
                _ => throw new RepositoryException(ErrorConstants.RepositoryTypeEntities)
            };
        }

        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity"></param>
        public void AddToRepository(TResource entity)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(AddToRepository));
            _fileRepository.AddToRepository(entity, _repositoryReader, _repositoryWriter);
            _loggerService.LogEnd(logId);
        }

        /// <summary>
        /// Delete from repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        public void DeleteFromRepository(int id)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(DeleteFromRepository));
            _fileRepository.DeleteFromRepository(id, _repositoryReader, _repositoryWriter);
            _loggerService.LogEnd(logId);
        }

        /// <summary>
        /// Get all form repository.
        /// </summary>
        /// <returns>Entity for success, null for fail.</returns>
        public IEnumerable<TResource>? GetAllFromRepository()
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(GetByIdFromRepository));
            var result = _fileRepository.GetAllFromRepository(_repositoryReader);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Get entity by id form repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <returns>Entity for success, null for fail.</returns>
        public TResource? GetByIdFromRepository(int id)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(GetByIdFromRepository));
            var result = _fileRepository.GetByIdFromRepository(id, _repositoryReader);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Get entities by id form repository.
        /// </summary>
        /// <param name="ids">id of entity.</param>
        /// <returns>List of entities for success, null for fail.</returns>
        public List<TResource> GetByIdFromRepository(IEnumerable<int> ids)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(GetByIdFromRepository));
            var result = _fileRepository.GetByIdFromRepository(ids, _repositoryReader);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Get entities by name form repository.
        /// </summary>
        /// <param name="name">name of entity.</param>
        /// <returns>List of entities for success, null for fail.</returns>
        public TResource? GetByNameFromRepository(string name)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(GetByNameFromRepository));
            var result = _fileRepository.GetByNameFromRepository(name, _repositoryReader);

            _loggerService.LogEnd(logId);
            return result;
        }

        /// <summary>
        /// Overwrite all entities of repository.
        /// </summary>
        /// <param name="entities">New entities for overwrite repository.</param>
        public void ReplaceRepository(IReadOnlyList<TResource> entities)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(ReplaceRepository));
            _fileRepository.ReplaceRepository(entities, _repositoryWriter);
            _loggerService.LogEnd(logId);
        }

        /// <summary>
        /// Update entity in repository.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        public void UpdateInRepository(TResource entity)
        {
            var logId = _loggerService.LogStart(GetType().Name, nameof(UpdateInRepository));
            _fileRepository.UpdateInRepository(entity, _repositoryReader, _repositoryWriter);
            _loggerService.LogEnd(logId);
        }
    }
}
