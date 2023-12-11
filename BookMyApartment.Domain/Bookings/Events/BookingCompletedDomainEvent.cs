using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid Id) : IDomainEvent;