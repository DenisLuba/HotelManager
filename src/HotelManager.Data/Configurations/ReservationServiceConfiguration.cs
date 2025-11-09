using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class ReservationServiceConfiguration : IEntityTypeConfiguration<ReservationService>
{
    public void Configure(EntityTypeBuilder<ReservationService> builder)
    {
        #region Table
        builder.ToTable("ReservationServices");
        #endregion

        #region Primary Key (ReservationId, ServiceId)
        builder.HasKey(reservationService => new { reservationService.ReservationId, reservationService.ServiceId });

        builder.Property(reservationService => reservationService.ReservationId)
            .HasColumnName("reservation_id");

        builder.Property(reservationService => reservationService.ServiceId)
            .HasColumnName("service_id");
        #endregion

        #region Relationships
        // ReservationService -> Reservation (Many-To-One)
        builder.HasOne(reservationService => reservationService.Reservation)
            .WithMany(reservation => reservation.ReservationServices)
            .HasForeignKey(reservationService => reservationService.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);

        // ReservationService -> Service (Many-To-One)
        builder.HasOne(reservationService => reservationService.Service)
            .WithMany(service => service.ReservationServices)
            .HasForeignKey(reservationService => reservationService.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}

