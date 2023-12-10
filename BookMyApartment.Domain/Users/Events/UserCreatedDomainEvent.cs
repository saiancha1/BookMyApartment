using BookMyApartment.Domain.Abstractions;

namespace BookMyApartment.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid Id) : IDomainEvent;