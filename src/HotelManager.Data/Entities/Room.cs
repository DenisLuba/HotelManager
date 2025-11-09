namespace HotelManager.Data.Entities;

public class Room
{
    #region Columns
    public int HotelId { get; set; }
    public int RoomNumber { get; set; }
    public int RoomTypeId { get; set; }
    public int Capacity { get; set; }
    public int GuestsNumber { get; set; }
    public decimal Price { get; set; }
    #endregion

    #region Navigation
    public Hotel Hotel { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
    #endregion

    #region Navigation Collection
    public ICollection<Reservation> Reservations { get; set; } = [];
    #endregion
}