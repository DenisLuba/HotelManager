namespace HotelManager.Data.Entities;

public record Client(
    int Id, 
    string FirstName, 
    string? LastName, 
    string? Email, 
    string? PhoneNumber, 
    ICollection<Reservation> Reservations
);
