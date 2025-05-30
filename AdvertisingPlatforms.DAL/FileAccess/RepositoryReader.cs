using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Extensions;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;

namespace AdvertisingPlatforms.DAL.FileAccess
{
    public class RepositoryReader : IRepositoryReader
    {
        private ILoggerService _loggerService;
        public RepositoryReader(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        /// <summary>
        /// Method for reading all entities from json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="filePath">Path for file with data.</param>
        /// <returns>List of entities.</returns>
        /// <exception cref="RepositoryException"></exception>
        public List<TResource> GetAllFromFile<TResource>(string filePath) where TResource : Resource
        {
            if (this.TryReadData(filePath, out List<TResource>? data, _loggerService))
            {
                return data;
            }
            else
            {
                throw new RepositoryException(ErrorConstants.ReadRepository);
            }
        }
    }
}
