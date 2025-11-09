using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Data.Entities;

public class Room
{
    #region Columns
    [Required]
    [Column("hotel_id")]
    public int HotelId { get; set; } // Foreign Key to Hotel

    [Required]
    [Column("room_number")]
    public int RoomNumber { get; set; }

    [Required]
    [Column("room_type_id")]
    public int RoomTypeId { get; set; } // Foreign Key to RoomType

    [Required]
    [Column("capacity")]
    public int Capacity { get; set; }

    [Required]
    [Column("price")]
    public decimal Price { get; set; }

    [Required]
    [Column("guests_number")]
    public int GuestsNumber { get; set; }
    #endregion

    #region Navigation Properties
    public Hotel Hotel { get; set; } = null!;

    public RoomType RoomType { get; set; } = null!;
    #endregion

    #region Navigation Collections
    public ICollection<Reservation> Reservations { get; set; } = [];
    #endregion
}
