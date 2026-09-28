// <copyright file="IExceptionStrategyFactory.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Api.ExceptionHandling.Factories;

/// <summary>
/// Defines the factory contract for resolving the appropriate <see cref="IExceptionStrategy"/> for an exception.
/// </summary>
public interface IExceptionStrategyFactory
{
    /// <summary>
    /// Resolves and returns an exception strategy suitable for the specified exception.
    /// </summary>
    /// <param name="exception">The encountered exception.</param>
    /// <returns>An implementation of <see cref="IExceptionStrategy"/>.</returns>
    IExceptionStrategy GetExceptionStrategy(Exception exception);
}
