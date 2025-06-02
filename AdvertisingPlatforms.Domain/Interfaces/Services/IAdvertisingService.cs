using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for service of platforms.
    /// </summary>
    public interface IAdvertisingService: IReplaceData<Advertising>
    {
        /// <summary>
        /// Get all advertising by IDs.
        /// </summary>
        /// <param name="advertisingIds">ID of advertising platform.</param>
        /// <returns>List of advertising or null.</returns>
        /// <exception cref="GetAdvertisingException"></exception>
        public List<Advertising>? GetAllByIds(IEnumerable<int> advertisingIds);

        /// <summary>
        /// Get all advertising from repository.
        /// </summary>
        /// <returns>Collection advertising or null.</returns>
        public IEnumerable<Advertising>? GetAll();

        /// <summary>
        /// Get advertising by id.
        /// </summary>
        /// <param name="id">Id for advertising.</param>
        /// <returns></returns>
        public Advertising? GetById(int id);

        /// <summary>
        /// Delete advertising.
        /// </summary>
        /// <param name="id">Id for advertising.</param>
        public void Delete(int id);

        /// <summary>
        /// Update advertising.
        /// </summary>
        /// <param name="advertising">Advertising.</param>
        public void Update(Advertising advertising);

        /// <summary>
        /// Add advertising to repository.
        /// </summary>
        /// <param name="advertising">Advertising.</param>
        public void Add(Advertising advertising);
    }
}
