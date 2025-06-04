using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.Models
{
    /// <summary>
    /// Advertising platform model for Sql-database.
    /// </summary>
    public class AdvertisingPlatformForSqlDb: AdvertisingPlatform
    {
        /// <summary>
        /// IDs of advertising platforms available for the location.
        /// </summary>
        new public List<int> AdvertisingIds => base.AdvertisingIds.ToList();

        /// <summary>
        /// Create a model that displays the availability of advertising platforms for a location.
        /// </summary>
        /// <param name="id">ID of model.</param>
        /// <param name="locationId">ID of location.</param>
        /// <param name="advertisingIds">IDs of advertising platforms available for the location.</param>
        public AdvertisingPlatformForSqlDb(int id, int locationId, List<int> advertisingIds) : base(id, locationId, advertisingIds) { }
    }
}
