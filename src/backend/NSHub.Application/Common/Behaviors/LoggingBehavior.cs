// <copyright file="LoggingBehavior.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Logging;

namespace NSHub.Application.Common.Behaviors;

/// <summary>
/// Provides logging for CQRS requests as they pass through the MediatR pipeline.
/// Logs the start, completion, and execution time of each request.
/// </summary>
/// <typeparam name="TRequest">The type of the request being processed.</typeparam>
/// <typeparam name="TResponse">The type of the response returned by the request.</typeparam>
public class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    /// <summary>
    /// Processes the request, logging execution details before and after the request handler is invoked.
    /// </summary>
    /// <param name="request">The request being handled.</param>
    /// <param name="next">
    /// The delegate representing the next action in the pipeline.
    /// </param>
    /// <param name="cancellationToken">
    /// A token used to observe cancellation requests.
    /// </param>
    /// <returns>
    /// The response returned by the request handler.
    /// </returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        logger.LogInformation(
            "NSHub CQRS Executing: {RequestName}",
            requestName);

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        var response = await next();

        stopwatch.Stop();

        logger.LogInformation(
            "NSHub CQRS Completed: {RequestName} in {ElapsedMilliseconds}ms",
            requestName,
            stopwatch.ElapsedMilliseconds);

        return response;
    }
}
