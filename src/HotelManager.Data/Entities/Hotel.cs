namespace HotelManager.Data.Entities;

public record Hotel(
    int Id,
    string Name,
    string Address,
    double? Raiting,
    string? Description,
    bool IsMainHotel,
    ICollection<Room> Rooms
);

