using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.FileAccess
{
    /// <summary>
    /// Repository for working with files.
    /// </summary>
    /// <typeparam name="TResource">Resource</typeparam>
    public class FileRepository<TResource> where TResource : Resource
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        public void AddToRepository(TResource entity, IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            var repositoryEntities = repositoryReader.GetAllFromFile<TResource>(_filePath);

            var haveEntity = repositoryEntities.Find(x=> x.Id == entity.Id);

            if (haveEntity != null)
                throw new RepositoryException(ErrorConstants.Argument);

            repositoryEntities.Add(entity);
            repositoryWriter.SaveChangesToFile( _filePath,repositoryEntities);
        }

        /// <summary>
        /// Delete from repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        public void DeleteFromRepository(int id, IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            var repositoryEntities = repositoryReader.GetAllFromFile<TResource>(_filePath);

            var entityForDelete = repositoryEntities.Find(x => x.Id == id);

            if (entityForDelete == null)
                throw new RepositoryException(ErrorConstants.EntityNotFound);

            repositoryEntities.Remove(entityForDelete);
            repositoryWriter.SaveChangesToFile(_filePath, repositoryEntities);
        }

        /// <summary>
        /// Get all from repository.
        /// </summary>
        /// <param name="repositoryReader">Reader for repository.</param>
        public IEnumerable<TResource>? GetAllFromRepository(IRepositoryReader repositoryReader)
        {
            var result = repositoryReader.GetAllFromFile<TResource>(_filePath);

            if (result == null)
                throw new RepositoryException(ErrorConstants.EntityNotFound);

            return result;
        }

        /// <summary>
        /// Get entity by id form repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <returns>Entity for success, null for fail.</returns>
        public TResource? GetByIdFromRepository(int id, IRepositoryReader repositoryReader)
        {
            var result = repositoryReader.GetAllFromFile<TResource>(_filePath).Find(x => x.Id == id);

            if (result == null)
                throw new RepositoryException(ErrorConstants.EntityNotFound);

            return result;
        }

        /// <summary>
        /// Get entities by id form repository.
        /// </summary>
        /// <param name="ids">id of entity.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <returns>List of entities for success, empty collection for fail.</returns>
        public List<TResource> GetByIdFromRepository(IEnumerable<int> ids, IRepositoryReader repositoryReader)
        {
            var result = repositoryReader.GetAllFromFile<TResource>(_filePath).Where(x => ids.Contains(x.Id)).ToList();

            if (result.Count == 0)
                throw new RepositoryException(ErrorConstants.EntityNotFound);

            return result;
        }

        /// <summary>
        /// Get entity by name form repository.
        /// </summary>
        /// <param name="name">name of entity.</param>
        /// <returns>Entity for success, null for fail</returns>
        public TResource? GetByNameFromRepository(string name, IRepositoryReader repositoryReader)
        {
            var result = repositoryReader.GetAllFromFile<TResource>(_filePath).Find(x => x.Name == name);

            if (result == null)
                throw new RepositoryException(ErrorConstants.EntityNotFound);

            return result;
        }

        /// <summary>
        /// Overwrite all entities of repository.
        /// </summary>
        /// <param name="entities">New entities for overwrite repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        public void ReplaceRepository(IReadOnlyList<TResource> entities, IRepositoryWriter repositoryWriter)
        {
            repositoryWriter.SaveChangesToFile(_filePath, entities);
        }

        /// <summary>
        /// Update entity in repository.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        /// <exception cref="RepositoryException"></exception>
        public void UpdateInRepository(TResource entity, IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            var repositoryEntities = repositoryReader.GetAllFromFile<TResource>(_filePath);

            var entityForUpdate = repositoryEntities.Find(x => x.Id == entity.Id);

            if (entityForUpdate == null)
                throw new RepositoryException(ErrorConstants.EntityNotFound);

            entityForUpdate.Name = entity.Name;
            repositoryWriter.SaveChangesToFile(_filePath, repositoryEntities);
        }
    }
}
