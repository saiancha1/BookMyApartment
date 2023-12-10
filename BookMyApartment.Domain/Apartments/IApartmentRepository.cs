namespace BookMyApartment.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> GetByAsyncMethod(Guid id, CancellationToken cancellationToken = default);
}