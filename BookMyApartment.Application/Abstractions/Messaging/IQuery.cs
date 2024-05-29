using BookMyApartment.Domain.Abstractions;
using MediatR;

namespace BookMyApartment.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}