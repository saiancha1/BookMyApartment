using BookMyApartment.Domain.Abstractions;
using BookMyApartment.Domain.Users.Events;

namespace BookMyApartment.Domain.Users;

public sealed class User : Entity
{
    public User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    
    //Using static factory pattern to create the user incase we have fields in the constructor we do not want to expose.
    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        return user;
    }
}
