// <copyright file="IExceptionStrategyContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.Filters;

namespace NSHub.Api.ExceptionHandling;

/// <summary>
/// Defines the execution context contract for dispatching exceptions to their designated strategies.
/// </summary>
public interface IExceptionStrategyContext
{
    /// <summary>
    /// Evaluates and handles the exception within the supplied MVC exception context.
    /// </summary>
    /// <param name="context">The MVC exception context.</param>
    void HandleException(ExceptionContext context);
}
