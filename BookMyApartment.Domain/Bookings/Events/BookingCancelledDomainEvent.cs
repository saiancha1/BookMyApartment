using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(Guid Id) : IDomainEvent;