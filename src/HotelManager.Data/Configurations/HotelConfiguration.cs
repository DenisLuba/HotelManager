using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        #region Table
        builder.ToTable("Hotels");
        #endregion

        #region Id Property
        builder.HasKey(hotel => hotel.Id);

        builder.Property(hotel => hotel.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();
        #endregion

        #region Name Property
        builder.Property(hotel => hotel.Name)
               .HasColumnName("name")
               .IsRequired();
        #endregion

        #region Address Property
        builder.Property(hotel => hotel.Address)
               .HasColumnName("address")
               .IsRequired();
        #endregion

        #region Description Property
        builder.Property(hotel => hotel.Description)
               .HasColumnName("description");
        #endregion

        #region IsMainHotel Property
        builder.Property(hotel => hotel.IsMainHotel)
               .HasColumnName("is_main_hotel")
               .IsRequired();
        #endregion

        #region Raiting Property
        builder.Property(hotel => hotel.Raiting)
               .HasColumnName("raiting");
        #endregion

        #region Navigation
        // одна гостиница -> много комнат
        builder.HasMany(hotel => hotel.Rooms)
               .WithOne(rooms => rooms.Hotel)
               .HasForeignKey(rooms => rooms.HotelId)
               .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }
}

