namespace HotelManager.Data.Entities;

public class ReservationService
{
    #region Columns
    public int ReservationId { get; set; }
    public int ServiceId { get; set; } 
    #endregion

    #region Navigation
    public Reservation Reservation { get; set; } = null!;
    public Service Service { get; set; } = null!; 
    #endregion
}

