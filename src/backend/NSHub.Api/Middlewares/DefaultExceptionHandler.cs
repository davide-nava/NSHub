// <copyright file="DefaultExceptionHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NSHub.Api.Middlewares;

/// <summary>
/// Global exception handler for writing problem details to the HTTP response.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DefaultExceptionHandler"/> class.
/// </remarks>
/// <param name="problemDetailsService">The problem details service.</param>
/// <param name="logger">The logger instance.</param>
public class DefaultExceptionHandler(IProblemDetailsService problemDetailsService, ILogger<DefaultExceptionHandler> logger) : IExceptionHandler
{
    /// <inheritdoc/>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        ArgumentNullException.ThrowIfNull(exception);

        ProblemDetailsContext problem = new()
        {
            HttpContext = httpContext,
            AdditionalMetadata = httpContext.Features?.Get<IExceptionHandlerFeature>()?.Endpoint?.Metadata,
            ProblemDetails =
            {
                Status = httpContext.Response?.StatusCode,
                Title = exception.GetType().FullName,
                Detail = exception.Message,
            },
            Exception = exception,
        };

        await problemDetailsService.WriteAsync(problem);

        if (logger.IsEnabled(LogLevel.Error))
        {
            logger.LogError(exception, "ProblemDetailsContext {@ProblemDetailsContext}", problem);
        }

        return true;
    }
}
