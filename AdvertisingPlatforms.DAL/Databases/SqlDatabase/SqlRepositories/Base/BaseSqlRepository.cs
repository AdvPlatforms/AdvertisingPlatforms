using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Databases.SqlDatabase.Data;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPlatforms.DAL.Databases.SqlDatabase.SqlRepositories.Base
{
    public abstract class BaseSqlRepository<TResource> : IRepository<TResource> where TResource : Resource
    {
        protected readonly AppDbContext _appDbContext;
        protected DbSet<TResource>? _entitiesOfRepository;

        public BaseSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entitiesOfRepository = GetDbSet();
        }

        private DbSet<TResource>? GetDbSet()
        {
            return typeof(TResource).Name switch
            {
                "Advertising" => _appDbContext.Advertisings as DbSet<TResource>,
                "AdvertisingPlatform" => _appDbContext.AdvertisingPlatforms as DbSet<TResource>,
                "Location" => _appDbContext.Locations as DbSet<TResource>,
                _ => throw new RepositoryException(ErrorConstants.RepositoryTypeEntities)
            };
        }

        public void AddToRepository(TResource entity)
        {
            var entityInRepository = _entitiesOfRepository?.FirstOrDefault(x=>x.Id == entity.Id);
            if (entityInRepository != null)
                throw new RepositoryException(ErrorConstants.Argument);

            _entitiesOfRepository?.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void DeleteFromRepository(int id)
        {
            var entityInRepository = _entitiesOfRepository?.FirstOrDefault(x=>x.Id == id);
            if (entityInRepository == null)
                throw new RepositoryException(ErrorConstants.Argument);

            _entitiesOfRepository?.Remove(entityInRepository);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<TResource>? GetAllFromRepository()
        {
            if (_entitiesOfRepository?.Count() == 0)
                throw new RepositoryException(ErrorConstants.NotFound);

            return _entitiesOfRepository;
        }

        public TResource? GetByIdFromRepository(int id)
        {
            var entityInRepository = _entitiesOfRepository?.FirstOrDefault(x => x.Id == id);
            if (entityInRepository == null)
                throw new RepositoryException(ErrorConstants.NotFound);

            return entityInRepository;
        }

        public List<TResource> GetByIdFromRepository(IEnumerable<int> ids)
        {
            var result = _entitiesOfRepository?.Where(x => ids.Contains(x.Id));

            if(result == null || result.Count() == 0)
                throw new RepositoryException(ErrorConstants.NotFound);

            return result.ToList();
        }

        public TResource? GetByNameFromRepository(string name)
        {
            var entityInRepository = _entitiesOfRepository?.FirstOrDefault(x => x.Name == name);
            if (entityInRepository == null)
                throw new RepositoryException(ErrorConstants.NotFound);

            return entityInRepository;
        }

        public virtual void ReplaceRepository(IReadOnlyList<TResource> entities)
        {
            _entitiesOfRepository?.RemoveRange(_entitiesOfRepository);
            _entitiesOfRepository?.AddRange(entities);
            _appDbContext.SaveChanges();
        }

        public void UpdateInRepository(TResource entity)
        {
            var entityInRepository = _entitiesOfRepository?.FirstOrDefault(x => x.Id == entity.Id);
            if (entityInRepository == null)
                throw new RepositoryException(ErrorConstants.Argument);

            _entitiesOfRepository?.Update(entityInRepository);
            _appDbContext.SaveChanges();
        }
    }
}
