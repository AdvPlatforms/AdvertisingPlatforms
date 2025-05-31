using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.DAL.Repositories.Base;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisingPlatforms for working with a json file.
    /// </summary>
    public class AdvertisingFileRepository : Repository<Advertising>
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
