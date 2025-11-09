using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        #region Table
        builder.ToTable("Rooms");
        #endregion

        #region Primary Key (HotelId, RoomNumber)
        builder.HasKey(rooms => new { rooms.HotelId, rooms.RoomNumber });

        builder.Property(rooms => rooms.HotelId)
            .HasColumnName("hotel_id")
            .IsRequired();

        builder.Property(rooms => rooms.RoomNumber)
            .HasColumnName("room_number")
            .IsRequired();
        #endregion

        #region RoomTypeId Property 
        builder.Property(rooms => rooms.RoomTypeId)
            .HasColumnName("room_type_id")
            .IsRequired();
        #endregion

        #region Capacity Property
        builder.Property(rooms => rooms.Capacity)
            .HasColumnName("capacity")
            .IsRequired();
        #endregion

        #region GuestsNumber Property
        builder.Property(rooms => rooms.GuestsNumber)
            .HasColumnName("guests_number")
            .HasDefaultValue(0)
            .IsRequired();
        #endregion

        #region Price Property
        builder.Property(rooms => rooms.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(10,2)")
            .IsRequired();
        #endregion

        #region Constraints
        builder.ToTable(table => table.HasCheckConstraint(
            name: "CK_Rooms_GuestsNumber_Capacity",
            sql: "\"guests_number\" <= \"capacity\""
        ));
        #endregion

        #region Relationships
        // Room -> Hotel (Many-to-One)
        builder.HasOne(room => room.Hotel)
            .WithMany(hotel => hotel.Rooms)
            .HasForeignKey(room => room.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        // Room -> RoomType (Many-to-One)
        builder.HasOne(room => room.RoomType)
            .WithMany(roomType => roomType.Rooms)
            .HasForeignKey(room => room.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Room -> Reservation (One-to-Many)
        builder.HasMany(room => room.Reservations)
            .WithOne(reservation => reservation.Room)
            .HasForeignKey(reservation => new { reservation.HotelId, reservation.RoomNumber })
            .OnDelete(DeleteBehavior.Cascade); 
        #endregion
    }
}

