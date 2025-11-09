namespace HotelManager.Data.Entities;

public class Client
{
    #region Columns
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    #endregion

    #region Navigation Collection
    public ICollection<Reservation> Reservations { get; set; } = []; 
    #endregion
}
