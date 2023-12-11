using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Bookings;

public static class BookingErrors
{
    public static Error NotFound = new("Booking.Found", "The booking with the specified identifier was not found");
    public static Error NotReserved = new("Booking.NotReserved", "The booking is not pending");
    public static Error Overlap = new("Booking.Overlap", "The current booking is overlapping with an existing booking");
    public static Error NotConfirmed = new("Booking.NotReserved", "The booking is not reserved");
    public static Error AlreadyStarted = new("Booking.AlreadyStarted", "The booking has already started");
}