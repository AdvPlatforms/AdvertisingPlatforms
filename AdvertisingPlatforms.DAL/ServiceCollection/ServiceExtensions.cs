using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileAccess;
using AdvertisingPlatforms.DAL.Databases.FileDatabase.FileRepositories;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories;

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
            services.AddScoped<IRepositoryReader, RepositoryReader>();
            services.AddScoped<IRepositoryWriter, RepositoryWriter>();
            services.AddScoped<IRepository<Location>, LocationFileRepository>();
            services.AddScoped<IRepository<Advertising>, AdvertisingFileRepository>();
            services.AddScoped<IRepository<AdvertisingPlatform>, AdvertisingPlatformFileRepository>();

            //services.AddScoped<IRepository<Location>, LocationSqlRepository>();
            //services.AddScoped<IRepository<Advertising>, AdvertisingSqlRepository>();
            //services.AddScoped<IRepository<AdvertisingPlatform>, AdvertisingPlatformSqlRepository>();
        }
    }
}
