using HotelManager.Data.Entities;

namespace HotelManager.Data.Repositories.Interfaces;

public interface IClientRepository : IRepository<Client>
{
    Task<IEnumerable<Client>> GetClientsWithReservationsAsync();
}
