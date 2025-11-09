namespace HotelManager.Data.Entities;

public class Hotel
{
    #region Columns
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double? Raiting { get; set; }
    public string? Description { get; set; }
    public bool IsMainHotel { get; set; }
    #endregion

    #region Navigation Collection
    public ICollection<Room> Rooms { get; set; } = []; 
    #endregion
}

