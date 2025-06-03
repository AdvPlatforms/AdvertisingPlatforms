using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories.Base;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationFileRepository : FileFacadeRepository<Location>
    {
        /// <summary>
        /// Create repository for locations.
        /// </summary>
        /// <param name="repositoryReader">Repository reader.</param>
        /// <param name="repositoryWriter">Repository writer.</param>
        public LocationFileRepository(
            IRepositoryReader repositoryReader,
            IRepositoryWriter repositoryWriter,
            ILoggerService loggerService) : base(repositoryReader, repositoryWriter, loggerService) { }
    }
}
