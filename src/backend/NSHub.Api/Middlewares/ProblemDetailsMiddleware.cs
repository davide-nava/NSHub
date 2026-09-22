// <copyright file="ProblemDetailsMiddleware.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace NSHub.Api.Middleware;

/// <summary>
/// Middleware intercepting unhandled exceptions and converting them to standardized RFC 7807 ProblemDetails responses.
/// </summary>
/// <param name="next">The next request delegate in the HTTP pipeline.</param>
/// <param name="logger">The logger instance.</param>
public class ProblemDetailsMiddleware(RequestDelegate next, ILogger<ProblemDetailsMiddleware> logger)
{
    /// <summary>
    /// Processes an incoming HTTP request and catches any unhandled exceptions.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the completion of request processing.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception during HTTP request execution: {Path}", context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var problemDetails = new ProblemDetails
        {
            Status = context.Response.StatusCode,
            Title = "Internal Server Error",
            Detail = exception.Message,
            Instance = context.Request.Path,
            Type = "https://tools.ietf.org/html/rfc7807",
        };

        problemDetails.Extensions["traceId"] = context.TraceIdentifier;

        var json = JsonSerializer.Serialize(problemDetails, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });

        return context.Response.WriteAsync(json, context.RequestAborted);
    }
}
