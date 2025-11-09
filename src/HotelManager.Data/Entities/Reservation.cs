using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Data.Entities;

[Table("Reservations")]
public class Reservation
{
    #region Columns
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Client))]
    [Column("client_id")]
    public int ClientId { get; set; } // Foreign Key to Client

    [Required]
    [Column("hotel_id")]
    public int HotelId { get; set; } // Foreign Key to Room's Hotel

    [Required]
    [Column("room_number")]
    public int RoomNumber { get; set; } // Foreign Key to Room

    [Required]
    [Column("check_in_date")]
    public DateTime CheckInDate { get; set; }

    [Required]
    [Column("check_out_date")]
    public DateTime CheckOutDate { get; set; }
    #endregion

    #region Navigation Properties
    public Client Client { get; set; } = null!;

    public Room Room { get; set; } = null!;
    #endregion
}
