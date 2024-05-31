#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ST10023767_PROG.Repositories
{
    /// <summary>
    /// This class represents a base for repositories providing database connection functionality for part 2.
    /// </summary>
    public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        /// <summary>
        /// Database context for working with data
        /// </summary>
        protected readonly LocalDbContext _context;

        /// <summary>
        /// Entity set for the specified TEntity type
        /// </summary>
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Constructor for creating a new RepositoryBase instance
        /// </summary>
        public RepositoryBase(LocalDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Retrieve all entities of type TEntity from the repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Retrieve a specific entity by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Check if an entity with the given identifier exists in the repository.
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>True if the entity exists, otherwise false</returns>
        public bool Exists(int id)
        {
            return _dbSet.Find(id) != null;
        }

        /// <summary>
        /// Add a new entity to the repository and return its identifier
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();

            // Get the entry for the entity and then the primary key
            var entityId = _context.Entry(entity).Property("Id").CurrentValue;

            // Assuming the primary key is of type int
            return (int)entityId;
        }

        /// <summary>
        /// Update an existing entity in the repository
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Update an existing entity in the repository
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        public void Update(TEntity entity, object id)
        {
            var existingEntity = _dbSet.Find(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove an entity from the repository
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// Remove an entity from the repository using its unique identifier
        /// </summary>
        /// <param name="id"></param>
        public void RemoveById(int id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        /// <summary>
        /// Save changes made to the database
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Dispose of the database context when no longer needed
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Find all entities without tracking changes.
        /// </summary>
        /// <returns>An IQueryable collection of entities</returns>
        public IQueryable<TEntity> FindAll()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Find entities by a specified condition without tracking changes.
        /// </summary>
        /// <param name="expression">The condition to filter entities</param>
        /// <returns>An IQueryable collection of entities</returns>
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Create a new entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to create</param>
        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//