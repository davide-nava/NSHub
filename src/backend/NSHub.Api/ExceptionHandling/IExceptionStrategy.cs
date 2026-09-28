// <copyright file="IExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.Filters;

namespace NSHub.Api.ExceptionHandling;

/// <summary>
/// Defines a strategy for handling specific categories of exceptions within MVC action filters.
/// </summary>
public interface IExceptionStrategy
{
    /// <summary>
    /// Processes the intercepted exception and assigns the appropriate action result to the context.
    /// </summary>
    /// <param name="context">The MVC exception context.</param>
    void HandleException(ExceptionContext context);
}
