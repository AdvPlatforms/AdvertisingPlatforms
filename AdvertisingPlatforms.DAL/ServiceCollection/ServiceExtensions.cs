using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileAccess;
using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories;
using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.Data;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories;
using AdvertisingPlatforms.DAL.Configuration;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.DAL.Const;

namespace AdvertisingPlatforms.DAL.ServiceCollection
{
    /// <summary>
    /// Extensions for service collection.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method for registration repository services
        /// </summary>
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            switch (DbConfig.DatabaseType)
            {
                case "File":
                    services.AddScoped<IRepositoryReader, RepositoryReader>();
                    services.AddScoped<IRepositoryWriter, RepositoryWriter>();
                    services.AddScoped<IRepository<Location>, LocationFileRepository>();
                    services.AddScoped<IRepository<Advertising>, AdvertisingFileRepository>();
                    services.AddScoped<IRepository<AdvertisingPlatform>, AdvertisingPlatformFileRepository>();
                    break;

                case "Sql":
                    services.AddDbContext<AppDbContext>();
                    services.AddScoped<IRepository<Location>, LocationSqlRepository>();
                    services.AddScoped<IRepository<Advertising>, AdvertisingSqlRepository>();
                    services.AddScoped<IRepository<AdvertisingPlatform>, AdvertisingPlatformSqlRepository>();
                    break ;

                default:
                    throw new ConfigurationReadException(ErrorConstants.ConfigurationRead);
            }
        }
    }
}
