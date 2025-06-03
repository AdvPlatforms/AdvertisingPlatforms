using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories.Base;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisingInLocation for working with a json file.
    /// </summary>
    public class AdvertisingPlatformFileRepository : FileFacadeRepository<AdvertisingPlatform>
    {
        /// <summary>
        /// Create repository for advertising in location.
        /// </summary>
        /// <param name="repositoryReader">Repository reader.</param>
        /// <param name="repositoryWriter">Repository writer.</param>
        public AdvertisingPlatformFileRepository(
            IRepositoryReader repositoryReader, 
            IRepositoryWriter repositoryWriter,
            ILoggerService loggerService) : base(repositoryReader, repositoryWriter, loggerService) { }
    }
}
