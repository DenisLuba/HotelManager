using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        #region Table
        builder.ToTable("RoomTypes");
        #endregion

        #region Id Property
        builder.HasKey(roomType => roomType.Id);

        builder.Property(roomType => roomType.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();
        #endregion

        #region TypeName Property
        builder.Property(roomType => roomType.TypeName)
               .HasColumnName("type_name")
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(roomType => roomType.TypeName).IsUnique();
        #endregion

        #region Description Property
        builder.Property(roomType => roomType.Description)
               .HasColumnName("description")
               .HasMaxLength(250);
        #endregion

        #region Navigation
        builder.HasMany(roomType => roomType.Rooms)
               .WithOne(rooms => rooms.RoomType)
               .HasForeignKey(rooms => rooms.RoomTypeId)
               .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }
}

