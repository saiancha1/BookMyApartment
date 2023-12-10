namespace BookMyApartment.Domain.Apartments;

public record Address(
    string Street,
    string City,
    string ZipCode,
    string Country);