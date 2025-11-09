namespace HotelManager.Data.Entities;

public class Service
{
    #region Columns
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    #endregion

    #region Navigation Collection
    public ICollection<ReservationService> ReservationServices { get; set; } = [];
    #endregion
}

