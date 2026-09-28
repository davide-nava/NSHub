// <copyright file="ExceptionStrategyContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.Filters;
using NSHub.Api.ExceptionHandling.Factories;

namespace NSHub.Api.ExceptionHandling;

/// <summary>
/// Context orchestrator resolving and invoking the appropriate exception strategy for an incoming exception context.
/// </summary>
/// <param name="exceptionStrategyFactory">The factory used to resolve exception strategies.</param>
public class ExceptionStrategyContext(IExceptionStrategyFactory exceptionStrategyFactory) : IExceptionStrategyContext
{
    /// <summary>
    /// Dispatches the exception in the context to its resolved handling strategy.
    /// </summary>
    /// <param name="context">The MVC exception context.</param>
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var strategy = exceptionStrategyFactory.GetExceptionStrategy(context.Exception);
        strategy.HandleException(context);
    }
}
