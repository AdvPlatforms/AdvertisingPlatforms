using AdvertisingPlatforms.DAL.Databases.SqlDatabase.Data;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories.Base;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories
{
    public class AdvertisingSqlRepository : BaseSqlRepository<Advertising>
    {
        public AdvertisingSqlRepository(AppDbContext appDbContext): base(appDbContext) { }
    }
}
