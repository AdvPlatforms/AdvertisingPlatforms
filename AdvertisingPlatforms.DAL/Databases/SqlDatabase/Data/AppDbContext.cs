using AdvertisingPlatforms.DAL.Configuration;
using AdvertisingPlatforms.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.Data
{
    public class AppDbContext: DbContext
    {
        private readonly bool _runForMigration;

        public AppDbContext(IServiceProvider serviceProvider) 
        {
            _runForMigration = serviceProvider != null;
        }

        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AdvertisingPlatform> AdvertisingPlatforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_runForMigration) 
            {
                optionsBuilder.UseNpgsql("Host=88.218.62.221;Port=5432;Database=delivery3;Username=user3;Password=P@ssw0rd_3");
            }
            else
            {
                optionsBuilder.UseNpgsql(DbConfig.ConnectionString);
            }
        }
    }
}
