using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Data.Database;

public class HotelDbContext : DbContext
{
    // этот конструктор нужен для того, чтобы EF Core через DI создал экземпляр HotelDbContext,
    // передавая в него параметры подключения, поведение кэша, логгеры и т.д.
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }

    // DbSet для всех таблиц, чтобы был удобный доступ к таблицам через LINQ
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<ReservationService> ReservationsService => Set<ReservationService>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Автоматически применяем все конфигурации из сборки
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

