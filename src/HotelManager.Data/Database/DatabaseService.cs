using Microsoft.EntityFrameworkCore;

namespace HotelManager.Data.Database;

public class DatabaseService(IDbContextFactory<HotelDbContext> contextFactory)
{
    public async Task<HotelDbContext> CreateContextAsync()
        => await contextFactory.CreateDbContextAsync();
}