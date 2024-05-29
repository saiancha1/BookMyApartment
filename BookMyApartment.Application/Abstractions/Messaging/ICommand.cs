﻿using BookMyApartment.Domain.Abstractions;
using MediatR;

namespace BookMyApartment.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}

public interface IBaseCommand
{
}