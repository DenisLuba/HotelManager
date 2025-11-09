namespace HotelManager.Data.Entities;

public record Service(
    int Id,
    string Description,
    decimal Price,
    ICollection<ReservationService> ReservationServices
);

