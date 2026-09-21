// <copyright file="ExceptionStrategyContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.Filters;
using NSHub.Api.ExceptionHandling.Factories;

namespace NSHub.Api.ExceptionHandling;

public class ExceptionStrategyContext(IExceptionStrategyFactory exceptionStrategyFactory) : IExceptionStrategyContext
{
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var strategy = exceptionStrategyFactory.GetExceptionStrategy(context.Exception);
        strategy.HandleException(context);
    }
}
