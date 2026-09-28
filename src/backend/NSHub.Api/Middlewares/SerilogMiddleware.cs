// <copyright file="SerilogMiddleware.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Reflection;
using NSHub.Application.Enums;
using Serilog.Context;

namespace NSHub.Api.Middlewares;

/// <summary>
/// Middleware enriching the Serilog LogContext with HTTP request details, machine identity, and user authentication claims.
/// </summary>
/// <param name="next">The next request delegate in the HTTP pipeline.</param>
public class SerilogMiddleware(RequestDelegate next)
{
    /// <summary>
    /// Enriches the Serilog log context with request parameters and dispatches the request to the next middleware.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <returns>A task representing asynchronous request execution.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        _ = LogContext.PushProperty(nameof(SerilogType.Date), DateTime.Now);
        _ = LogContext.PushProperty(nameof(SerilogType.MachineName), Environment.MachineName);
        _ = LogContext.PushProperty(nameof(SerilogType.Host), httpContext.Request.Host.Host);
        _ = LogContext.PushProperty(nameof(SerilogType.RequestIp), httpContext.Request.Host.Value);
        _ = LogContext.PushProperty(nameof(SerilogType.EndpointDisplayName), httpContext.GetEndpoint()?.DisplayName);
        _ = LogContext.PushProperty(nameof(SerilogType.CorrelationId), httpContext.TraceIdentifier);
        _ = LogContext.PushProperty(nameof(SerilogType.Email), httpContext.User?.Identity?.Name ?? string.Empty);
        _ = LogContext.PushProperty(nameof(SerilogType.Path), httpContext.Request?.Path.Value);
        _ = LogContext.PushProperty(nameof(SerilogType.Method), httpContext.Request?.Method);
        _ = LogContext.PushProperty(nameof(SerilogType.Application), Assembly.GetCallingAssembly().FullName);
        _ = LogContext.PushProperty(nameof(SerilogType.LogTypeId), "");
        _ = LogContext.PushProperty(nameof(SerilogType.TenantId), httpContext.User?.Claims?.FirstOrDefault(e => e.Type == nameof(SerilogType.TenantId))?.Value ??  null);
        _ = LogContext.PushProperty(nameof(SerilogType.UserId), httpContext.User?.Claims?.FirstOrDefault(e => e.Type == nameof(SerilogType.UserId))?.Value ?? "");

        await next(httpContext);
    }
}
