// <copyright file="ExceptionStrategyFactory.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NSHub.Api.ExceptionHandling.Strategies;
using NSHub.Application.Exceptions;

namespace NSHub.Api.ExceptionHandling.Factories;

public class ExceptionStrategyFactory(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategyFactory
{
    public IExceptionStrategy GetExceptionStrategy(Exception exception)
    {
        return exception switch
        {
            NotFoundException => new NotFoundExceptionStrategy(problemDetailsFactory),
            EntityNotFoundException => new NotFoundExceptionStrategy(problemDetailsFactory),
            UnauthorizedException => new UnauthorizedExceptionStrategy(problemDetailsFactory),
            ValidationException => new ValidationExceptionStrategy(problemDetailsFactory),
            _ => new UnknownExceptionStrategy(problemDetailsFactory),
        };
    }
}
