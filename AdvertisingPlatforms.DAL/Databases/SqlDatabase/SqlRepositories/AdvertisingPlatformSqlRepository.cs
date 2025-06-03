using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories
{
    public class AdvertisingPlatformSqlRepository : IRepository<AdvertisingPlatform>
    {
        public void AddToRepository(AdvertisingPlatform entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromRepository(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdvertisingPlatform>? GetAllFromRepository()
        {
            throw new NotImplementedException();
        }

        public AdvertisingPlatform? GetByIdFromRepository(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdvertisingPlatform> GetByIdFromRepository(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public AdvertisingPlatform? GetByNameFromRepository(string name)
        {
            throw new NotImplementedException();
        }

        public void ReplaceRepository(IReadOnlyList<AdvertisingPlatform> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateInRepository(AdvertisingPlatform entity)
        {
            throw new NotImplementedException();
        }
    }
}
