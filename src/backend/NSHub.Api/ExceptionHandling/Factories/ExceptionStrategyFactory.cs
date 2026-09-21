// <copyright file="ExceptionStrategyFactory.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NSHub.Api.ExceptionHandling.Strategies;
using NSHub.Application.Exceptions;

namespace NSHub.Api.ExceptionHandling.Factories;

/// <summary>
/// Factory resolving and instantiating the appropriate exception handling strategy based on exception type.
/// </summary>
/// <param name="problemDetailsFactory">The factory producing standardized problem details.</param>
public class ExceptionStrategyFactory(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategyFactory
{
    /// <summary>
    /// Resolves the corresponding <see cref="IExceptionStrategy"/> based on the runtime type of the exception.
    /// </summary>
    /// <param name="exception">The intercepted exception.</param>
    /// <returns>A concrete exception strategy instance.</returns>
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
