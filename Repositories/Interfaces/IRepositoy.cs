using System.Linq.Expressions;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// Define the IRepository interface for working with entities of type TEntity.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all entities of type TEntity from the repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Get an entity of type TEntity by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity? GetById(object id);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Add a new entity of type TEntity to the repository and return an identifier.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(TEntity entity);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Update an existing entity of type TEntity in the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Remove an entity of type TEntity from the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Remove an entity of type TEntity from the repository using its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        void RemoveById(int id);

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Check if an entity with the given identifier exists in the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(int id);
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
    }
}
