using System.Diagnostics.CodeAnalysis;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using System.Runtime.CompilerServices;
using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileAccess;

namespace AdvertisingPlatforms.DAL.Extensions
{
    public static class RepositoryReaderExtensions
    {
        /// <summary>
        /// Checking the possibility to get the data.
        /// </summary>
        /// <typeparam name="TResource">Resource</typeparam>
        /// <param name="_"></param>
        /// <param name="filePath">Path for file.</param>
        /// <param name="data">Data from repository.</param>
        /// <returns></returns>
        public static bool TryReadData<TResource>(this RepositoryReader _, string filePath, [NotNullWhen(true)] out List<TResource>? data, ILoggerService loggerService) where TResource : Resource
        {
            var logId = loggerService.LogStart(nameof(RepositoryReaderExtensions), nameof(TryReadData));
            data = null;

            using StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, filePath));
            var jsonDb = sr.ReadToEnd();

            if (string.IsNullOrEmpty(jsonDb))
            {
                loggerService.LogInfo(ErrorConstants.ReadRepository,nameof(RepositoryReaderExtensions), nameof(TryReadData));
                return false;
            }

            try
            {
                data = JsonSerializer.Deserialize<List<TResource>>(jsonDb);

                loggerService.LogEnd(logId);
                return data != null;
            }
            catch (JsonException)
            {
                loggerService.LogInfo(nameof(JsonException), nameof(RepositoryReaderExtensions), nameof(TryReadData));
                return false;
            }
            catch (NotSupportedException)
            {
                loggerService.LogInfo(nameof(NotSupportedException), nameof(RepositoryReaderExtensions), nameof(TryReadData));
                return false;
            }
        }
    }
}
