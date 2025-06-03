using AdvertisingPlatforms.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AdvertisingPlatform> AdvertisingPlatforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=88.218.62.221;Port=5432;Database=delivery3;Username=user3;Password=P@ssw0rd_3");
        }
    }
}
