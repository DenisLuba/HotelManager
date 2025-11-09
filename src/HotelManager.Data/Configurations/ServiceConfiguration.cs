using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        #region Table
        builder.ToTable("Services");
        #endregion

        #region Id Property
        builder.HasKey(service => service.Id);

        builder.Property(service => service.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        #endregion

        #region Description Property
        builder.Property(service => service.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(50);
        #endregion

        #region Price Property
        builder.Property(service => service.Price)
            .HasColumnName("price")
            .IsRequired();
        #endregion

        #region Navigation
        builder.HasMany(service => service.ReservationServices)
            .WithOne(reservationServices => reservationServices.Service)
            .HasForeignKey(reservationServices => reservationServices.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }
}

