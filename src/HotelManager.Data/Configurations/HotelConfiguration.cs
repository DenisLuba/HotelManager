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
               .HasMaxLength(100)
               .IsRequired();
        #endregion

        #region Address Property
        builder.Property(hotel => hotel.Address)
               .HasColumnName("address")
               .HasMaxLength(100)
               .IsRequired();
        #endregion

        #region Description Property
        builder.Property(hotel => hotel.Description)
               .HasColumnName("description")
               .HasMaxLength(250);
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

        #region Relationships
        // одна гостиница -> много комнат
        builder.HasMany(hotel => hotel.Rooms)
               .WithOne(room => room.Hotel)
               .HasForeignKey(room => room.HotelId)
               .OnDelete(DeleteBehavior.Cascade); // при удалении отеля удалятся все комнаты
        #endregion
    }
}

