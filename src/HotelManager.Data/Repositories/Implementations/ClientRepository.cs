using HotelManager.Data.Database;
using HotelManager.Data.Entities;
using HotelManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManager.Data.Repositories.Implementations;

public class ClientRepository(HotelDbContext context) : Repository<Client>(context), IClientRepository
{
}
