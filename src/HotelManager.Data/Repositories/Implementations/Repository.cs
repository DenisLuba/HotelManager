using HotelManager.Data.Database;
using HotelManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManager.Data.Repositories.Implementations;

public class Repository<T>(
    HotelDbContext dbContext,
    DbSet<T> dbSet
) : IRepository<T> where T : class
{
    public async Task AddAsync(T? entity)
    {
        if (entity is null)
            return;

        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T>? entities)
    {
        if (entities is null)
            return;

        await dbSet.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> func)
    {
        return await dbSet.Where(func).ToListAsync();
    }

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task RemoveAsync(T? entity)
    {
        if (entity is null)
            return;

        dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<T>? entities)
    {
        if (entities is null)
            return;

        dbSet.RemoveRange(entities);
        await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}

