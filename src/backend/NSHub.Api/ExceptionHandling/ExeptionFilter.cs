// <copyright file="ExeptionFilter.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NSHub.Api.ExceptionHandling;

/// <summary>
/// The default exception handler.
/// </summary>
/// <param name="exceptionStrategyContext">The exception strategy context to manage the exception responses..</param>
/// <param name="logger">Logger.</param>
public class ExeptionFilter(IExceptionStrategyContext exceptionStrategyContext, ILogger<ExeptionFilter> logger) : IExceptionFilter
{
    /// <summary>
    /// Try handle asynchronously.
    /// </summary>
    /// <param name="context">Exception context.</param>
    public void OnException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (logger.IsEnabled(LogLevel.Error))
        {
            logger.LogError(context.Exception, "[{TraceId}] An error has occurred: {Message}", Activity.Current?.Id ?? context.HttpContext.TraceIdentifier, context.Exception.Message);
        }

        exceptionStrategyContext.HandleException(context);
    }
}
