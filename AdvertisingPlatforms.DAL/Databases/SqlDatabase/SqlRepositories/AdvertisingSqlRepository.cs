using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories
{
    public class AdvertisingSqlRepository : IRepository<Advertising>
    {
        public void AddToRepository(Advertising entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromRepository(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Advertising>? GetAllFromRepository()
        {
            throw new NotImplementedException();
        }

        public Advertising? GetByIdFromRepository(int id)
        {
            throw new NotImplementedException();
        }

        public List<Advertising> GetByIdFromRepository(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Advertising? GetByNameFromRepository(string name)
        {
            throw new NotImplementedException();
        }

        public void ReplaceRepository(IReadOnlyList<Advertising> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateInRepository(Advertising entity)
        {
            throw new NotImplementedException();
        }
    }
}
