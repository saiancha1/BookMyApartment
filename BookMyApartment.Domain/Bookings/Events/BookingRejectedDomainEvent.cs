using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid Id) : IDomainEvent;