using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;