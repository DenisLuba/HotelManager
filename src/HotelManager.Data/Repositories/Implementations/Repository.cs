using HotelManager.Data.Database;
using HotelManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManager.Data.Repositories.Implementations;

public class Repository<T>(
    HotelDbContext dbContext
) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> AddAsync(T? entity)
    {
        if (entity is null)
            return null;

        var entityEntry = await _dbSet.AddAsync(entity);
        var numEntities = await SaveRepositoryChangesAsync();
        if (numEntities == 0)
            return null;

        return entityEntry.Entity;
    }

    public async Task<int> AddRangeAsync(IEnumerable<T?>? entities)
    {
        if (entities is null) return 0;

        entities = entities.Where(entity => entity is not null);
        if (!entities.Any()) return 0;

        await _dbSet.AddRangeAsync(entities!);
        return await SaveRepositoryChangesAsync();
    }

    public async Task<T?> RemoveAsync(T? entity)
    {
        if (entity is null) return null;

        var entityEntry = _dbSet.Remove(entity);
        if (entityEntry is null) return null;

        var numEntities = await SaveRepositoryChangesAsync();
        if (numEntities == 0) return null;

        return entityEntry.Entity;
    }

    public async Task<int> RemoveRangeAsync(IEnumerable<T?>? entities)
    {
        if (entities is null) return 0;

        entities = entities.Where(entity => entity is not null);
        if (!entities.Any()) return 0;

        _dbSet.RemoveRange(entities!);
        return await SaveRepositoryChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> func)
    {
        return await _dbSet.Where(func).ToListAsync();
    }

    public async Task<int> SaveRepositoryChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}

