using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent() : IDomainEvent;