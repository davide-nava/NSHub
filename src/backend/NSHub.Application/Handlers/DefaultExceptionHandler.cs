// <copyright file="DefaultExceptionHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NSHub.Application.Handlers;

public class DefaultExceptionHandler(IProblemDetailsService problemDetailsService, ILogger<DefaultExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetailsContext problem = new()
        {
            HttpContext = httpContext,
            AdditionalMetadata = httpContext?.Features?.Get<IExceptionHandlerFeature>()?.Endpoint?.Metadata,
            ProblemDetails =
            {
                Status = httpContext?.Response?.StatusCode,
                Title = exception?.GetType()?.FullName,
                Detail = exception?.Message,
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
