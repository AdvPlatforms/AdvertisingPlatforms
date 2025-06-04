using AdvertisingPlatforms.DAL.Databases.SqlDatabase.Data;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.Models;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories.Base;
using AdvertisingPlatforms.Domain.Models;


namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories
{
    public class AdvertisingPlatformSqlRepository : BaseSqlRepository<AdvertisingPlatform>
    {
        public AdvertisingPlatformSqlRepository(AppDbContext appDbContext): base(appDbContext) { }

        public override void ReplaceRepository(IReadOnlyList<AdvertisingPlatform> entities)
        {
            _entitiesOfRepository?.RemoveRange(_entitiesOfRepository);

            var sub = entities.Select(x=> new AdvertisingPlatformForSqlDb(
                x.Id,
                x.LocationId,
                x.AdvertisingIds.ToList()));

             _entitiesOfRepository?.AddRange(sub);

             int a = _appDbContext.SaveChanges();          
        }
    }
}
