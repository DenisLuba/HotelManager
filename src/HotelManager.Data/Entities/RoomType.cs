namespace HotelManager.Data.Entities;

public class RoomType
{
    public int Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<Room> Rooms { get; set; } = [];
}
