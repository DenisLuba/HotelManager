namespace HotelManager.Data.Entities;

public record RoomType(
    int Id,
    string TypeName,
    string? Description,
    ICollection<Room> Rooms
);
