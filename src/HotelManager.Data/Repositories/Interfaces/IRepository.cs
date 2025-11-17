using System.Linq.Expressions;

namespace HotelManager.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    /// <summary>
    /// Get entity by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T?>> GetAllAsync();

    /// <summary>
    /// Add entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddAsync(T? entity);

    /// <summary>
    /// Add multiple entities
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task AddRangeAsync(IEnumerable<T>? entities);

    /// <summary>
    /// Remove entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task RemoveAsync(T? entity);

    /// <summary>
    /// Remove multiple entities
    /// </summary>
    /// <param name="entities">Entities to remove</param>
    /// <returns>Task</returns>
    Task RemoveRangeAsync(IEnumerable<T>? entities);

    // Для гибких запросов
    /// <summary>
    /// Find entities by condition
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> func);

    // Сохранение изменений
    /// <summary>
    /// Save changes to the data source
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
}
