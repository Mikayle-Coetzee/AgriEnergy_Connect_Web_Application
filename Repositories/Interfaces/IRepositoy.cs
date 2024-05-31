#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// Define the IRepository interface for working with entities of type TEntity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all entities of type TEntity from the repository.
        /// </summary>
        /// <returns>All entities of type TEntity.</returns>
        IEnumerable<TEntity> GetAll();

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Get an entity of type TEntity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier, if found; otherwise, null.</returns>
        TEntity? GetById(object id);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Add a new entity of type TEntity to the repository and return an identifier.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The identifier of the added entity.</returns>
        int Add(TEntity entity);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Update an existing entity of type TEntity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Remove an entity of type TEntity from the repository.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(TEntity entity);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Remove an entity of type TEntity from the repository using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to remove.</param>
        void RemoveById(int id);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Save the changes made to the repository.
        /// </summary>
        void SaveChanges();

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Check if an entity with the given identifier exists in the repository.
        /// </summary>
        /// <param name="id">The unique identifier to check.</param>
        /// <returns>True if an entity with the given identifier exists; otherwise, false.</returns>
        bool Exists(int id);

        /// <summary>
        /// Finds all entities of type TEntity in the repository.
        /// </summary>
        /// <returns>A queryable collection of TEntity.</returns>
        IQueryable<TEntity> FindAll();

        /// <summary>
        /// Finds entities of type TEntity in the repository based on a condition.
        /// </summary>
        /// <param name="expression">The condition to filter entities.</param>
        /// <returns>A queryable collection of TEntity that satisfies the condition.</returns>
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Creates a new entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        void Create(TEntity entity);
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
