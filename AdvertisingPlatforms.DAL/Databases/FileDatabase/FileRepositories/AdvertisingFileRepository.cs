using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories.Base;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories
{
    /// <summary>
    /// Repository of advertisingPlatforms for working with a json file.
    /// </summary>
    public class AdvertisingFileRepository : FileFacadeRepository<Advertising>
    {
        /// <summary>
        /// Create repository for advertising platforms.
        /// </summary>
        /// <param name="repositoryReader">Repository reader.</param>
        /// <param name="repositoryWriter">Repository writer.</param>
        public AdvertisingFileRepository(
            IRepositoryReader repositoryReader, 
            IRepositoryWriter repositoryWriter,
            ILoggerService loggerService) : base(repositoryReader, repositoryWriter, loggerService) { }
    }
}
