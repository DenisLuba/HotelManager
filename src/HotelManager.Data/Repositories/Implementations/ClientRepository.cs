using HotelManager.Data.Entities;
using HotelManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManager.Data.Repositories.Implementations;

public class ClientRepository(DbContext dbContext) : IClientRepository
{
    private readonly DbSet<Client> _clients = dbContext.Set<Client>();

    public async Task AddAsync(Client client)
    {
        await _clients.AddAsync(client);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Client entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Client>> FindAsync(Expression<Func<Client, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Client>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Client?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();

    public async Task UpdateAsync(Client entity)
    {
        _clients.Update(entity);
        await SaveChangesAsync();
    }
}
