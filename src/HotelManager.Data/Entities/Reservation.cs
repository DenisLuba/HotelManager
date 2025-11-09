namespace HotelManager.Data.Entities;

public class Reservation
{
    #region Columns
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int HotelId { get; set; }
    public int RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; } 
    #endregion

    #region Navigation
    public Client Client { get; set; } = null!;
    public Room Room { get; set; } = null!;
    #endregion

    #region Navigation Collection
    public ICollection<ReservationService> ReservationServices { get; set; } = [];
    #endregion
}
