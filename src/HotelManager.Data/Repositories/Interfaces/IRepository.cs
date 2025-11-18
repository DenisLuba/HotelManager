using System.Linq.Expressions;

namespace HotelManager.Data.Repositories.Interfaces;

/// <summary>
/// Generic repository interface providing basic CRUD operations
/// and query capabilities for a given entity type.
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Retrieves a single entity by its unique identifier.
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <returns>
    /// The entity instance if found; otherwise null.
    /// </returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all entities of the given type.
    /// </summary>
    /// <returns>
    /// Collection of all entities. Returns an empty collection if no entities exist.
    /// </returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Adds a new entity to the data source.
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <returns>
    /// The entity instance if it is added; otherwise null.
    /// </returns>
    Task<T?> AddAsync(T? entity);

    /// <summary>
    /// Adds multiple entities to the data source.
    /// </summary>
    /// <param name="entities">Collection of entities to add</param>
    /// <returns>
    /// Number of state entries written to the database.
    /// </returns>
    Task<int> AddRangeAsync(IEnumerable<T?>? entities);

    /// <summary>
    /// Removes an entity from the data source.
    /// </summary>
    /// <param name="entity">Entity instance to remove</param>
    /// <returns>
    /// The entity instance if it is removed; otherwise null.
    /// </returns>
    Task<T?> RemoveAsync(T? entity);

    /// <summary>
    /// Removes multiple entities from the data source.
    /// </summary>
    /// <param name="entities">Entities to remove</param>
    /// <returns>
    /// Number of state entries written to the database.
    /// </returns>
    Task<int> RemoveRangeAsync(IEnumerable<T?>? entities);

    /// <summary>
    /// Retrieves entities matching the specified filter expression.
    /// </summary>
    /// <param name="func">Predicate expression used for filtering entities</param>
    /// <returns>
    /// Collection of entities matching the provided condition.
    /// Returns an empty collection if no matching entities exist.
    /// </returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> func);

    /// <summary>
    /// Saves all pending changes to the underlying data source.
    /// </summary>
    /// <returns>
    /// Number of state entries written to the database.
    /// </returns>
    Task<int> SaveRepositoryChangesAsync();
}
