using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        #region Table
        builder.ToTable("Reservations");
        #endregion

        #region Id Column
        builder.HasKey(reservation => reservation.Id);

        builder.Property(reservation => reservation.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        #endregion

        #region ClientId Column
        builder.Property(reservation => reservation.ClientId)
            .HasColumnName("client_id")
            .IsRequired();
        #endregion

        #region HotelId Column
        builder.Property(reservation => reservation.HotelId)
            .HasColumnName("hotel_id")
            .IsRequired();
        #endregion

        #region RoomNumber Column
        builder.Property(reservation => reservation.RoomNumber)
            .HasColumnName("room_number")
            .IsRequired();
        #endregion

        #region CheckInDate Column
        builder.Property(reservation => reservation.CheckInDate)
            .HasColumnName("check_in_date")
            .IsRequired();
        #endregion

        #region CheckOutDate Column
        builder.Property(reservation => reservation.CheckOutDate)
            .HasColumnName("check_out_date")
            .IsRequired();
        #endregion

        #region Relationships
        // Reservation -> Client (Many-To-One)
        builder.HasOne(reservation => reservation.Client)
            .WithMany(client => client.Reservations)
            .HasForeignKey(reservation => reservation.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Reservation -> Room (Many-To-One, Composite Key)
        builder.HasOne(reservation => reservation.Room)
            .WithMany(room => room.Reservations)
            .HasForeignKey(reservation => new { reservation.HotelId, reservation.RoomNumber })
            .HasPrincipalKey(room => new {room.HotelId,  room.RoomNumber})
            .OnDelete(DeleteBehavior.Cascade);

        // Reservation -> ReservatinService (One-To-Many)
        builder.HasMany(reservation => reservation.ReservationServices)
            .WithOne(reservationService => reservationService.Reservation)
            .HasForeignKey(reservationService => reservationService.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}

