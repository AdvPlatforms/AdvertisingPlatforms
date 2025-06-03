using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.DAL.Interfaces
{
    public interface IRepository<TResource> where TResource : Resource
    {
        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity"></param>
        public void AddToRepository(TResource entity);

        /// <summary>
        /// Delete from repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        public void DeleteFromRepository(int id);

        /// <summary>
        /// Get all form repository.
        /// </summary>
        /// <returns>Entity for success, null for fail.</returns>
        public IEnumerable<TResource>? GetAllFromRepository();

        /// <summary>
        /// Get entity by id form repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <returns>Entity for success, null for fail.</returns>
        public TResource? GetByIdFromRepository(int id);

        /// <summary>
        /// Get entities by id form repository.
        /// </summary>
        /// <param name="ids">id of entity.</param>
        /// <returns>List of entities for success, null for fail.</returns>
        public List<TResource> GetByIdFromRepository(IEnumerable<int> ids);

        /// <summary>
        /// Get entities by name form repository.
        /// </summary>
        /// <param name="name">name of entity.</param>
        /// <returns>List of entities for success, null for fail.</returns>
        public TResource? GetByNameFromRepository(string name);

        /// <summary>
        /// Overwrite all entities of repository.
        /// </summary>
        /// <param name="entities">New entities for overwrite repository.</param>
        public void ReplaceRepository(IReadOnlyList<TResource> entities);

        /// <summary>
        /// Update entity in repository.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        public void UpdateInRepository(TResource entity);
    }
}
