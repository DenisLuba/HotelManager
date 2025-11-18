using HotelManager.Data.Database;
using HotelManager.Data.Entities;
using HotelManager.Data.Repositories.Interfaces;

namespace HotelManager.Data.Repositories.Implementations;

public class ServiceRepository(HotelDbContext context) : Repository<Service>(context), IServiceRepository
{
}
