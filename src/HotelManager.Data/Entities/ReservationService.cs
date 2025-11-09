namespace HotelManager.Data.Entities;

public record ReservationService(
    int ReservationId,
    int ServiceId,
    Reservation Reservation,
    Service Service
);

