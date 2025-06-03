using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories
{
    public class LocationSqlRepository : IRepository<Location>
    {
        public void AddToRepository(Location entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromRepository(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location>? GetAllFromRepository()
        {
            throw new NotImplementedException();
        }

        public Location? GetByIdFromRepository(int id)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetByIdFromRepository(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Location? GetByNameFromRepository(string name)
        {
            throw new NotImplementedException();
        }

        public void ReplaceRepository(IReadOnlyList<Location> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateInRepository(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}
