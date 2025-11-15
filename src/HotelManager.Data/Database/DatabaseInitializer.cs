using Microsoft.EntityFrameworkCore;

namespace HotelManager.Data.Database;

public static class DatabaseInitialize
{
    public static void Initialize(HotelDbContext dbContext)
    {
        dbContext.Database.Migrate();
    }
}
