using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;

namespace AdvertisingPlatforms.DAL.Databases.FileDatabase.FileAccess
{
    public class RepositoryWriter : IRepositoryWriter
    {
        /// <summary>
        /// Method for writing all entities to json-file.
        /// </summary>
        /// <typeparam name="TResource">notnull, Resource</typeparam>
        /// <param name="filePath">Path for file.</param>
        /// <param name="newDataForDb">List of entities for writing.</param>
        public void SaveChangesToFile<TResource>(string filePath, IReadOnlyList<TResource> newDataForDb) where TResource : Resource
        {
            var newDbJson = JsonSerializer.Serialize(newDataForDb, new JsonSerializerOptions() { WriteIndented = true });

            using StreamWriter sw = new StreamWriter(Path.Combine(AppContext.BaseDirectory, filePath), false);

            sw.Write(newDbJson);
        }
    }
}
