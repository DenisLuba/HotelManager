using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelManager.Data.Database;

public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<HotelDbContext>();
        var path = Path.Combine(AppContext.BaseDirectory, DbConstants.DatabaseFileName);
        builder.UseSqlite($"Data Source={path}");
        return new HotelDbContext(builder.Options);
    }
}
