using HotelManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        #region Table
        builder.ToTable("Clients");                                     // = CREATE TABLE "Clients" 
        #endregion

        #region Id Property
        builder.HasKey(client => client.Id);                            // PRIMARY KEY 

        builder.Property(client => client.Id)
               .HasColumnName("id")                                     // "id"
               .ValueGeneratedOnAdd();                                  // AUTOINCREMENT
        #endregion                                                      
                                                                        
        #region FirstName Property                                      
        builder.Property(client => client.FirstName)                    
               .HasColumnName("first_name")                             // "first_name"
               .IsRequired()                                            // NOT NULL
               .HasMaxLength(20);                                       // VARCHAR(20) 
        #endregion                                                      
                                                                        
        #region LastName Property                                       
        builder.Property(client => client.LastName)                     
               .HasColumnName("last_name")                              // "last_name"
               .HasMaxLength(20);                                       // VARCHAR(20)
        #endregion

        #region Email Property
        builder.Property(client => client.Email)
               .HasColumnName("email")                                  // "email"
               .HasMaxLength(100);                                      // VARCHAR(100)
                                                                        
        builder.HasIndex(client => client.Email).IsUnique();            // CREATE UNIQUE INDEX IX_Clients_Email ON Clients (email)
        #endregion                                                      
                                                                        
        #region PhoneNumber Property                                    
        builder.Property(client => client.PhoneNumber)                  
               .HasColumnName("phone_number")                           // "phone_number
               .HasMaxLength(13);                                       // VARCHAR(13)
                                                                        
        builder.HasIndex(client => client.PhoneNumber).IsUnique();      // CREATE UNIQUE INDEX IX_Clients_PhoneNumber ON Clients (phone_number)
        #endregion                                                      
                                                                        
        #region Constraints                                             
                                                                        
        builder.ToTable(table => {                                      
            // Email Constraint                                         
            table.HasCheckConstraint(                                   // CONSTRAINT
                    name: "email_check",                                // "email_check
                    sql: "\"email\" LIKE '%_@_%._%'");                  // CHECK("email" LIKE '%_@_%._%')
                                                                        
            // PhoneNumber Constraint                                   
            table.HasCheckConstraint(                                   // CONSTRAINT
                    name: "phone_check",                                // "phone_check"
                    sql: "length(\"phone_number\") BETWEEN 10 AND 13"); // CHECK(length("phone_number") BETWEEN 10 AND 13)
        });   
        #endregion

        #region Relationships 
        // Client -> Reservation (один клиент -> много бронирований (Reservations))
        builder.HasMany(client => client.Reservations)
               .WithOne(reservation => reservation.Client)
               .HasForeignKey(reservation => reservation.ClientId)
               .OnDelete(DeleteBehavior.Cascade); // при удалении клиента удалятся все его бронирования
        #endregion
    }
}

