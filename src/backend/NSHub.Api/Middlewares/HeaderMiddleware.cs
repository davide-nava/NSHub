// <copyright file="HeaderMiddleware.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Interfaces;
using NSHub.Domain.Enums;

namespace NSHub.Api.Middlewares;

/// <summary>
/// Middleware populating request-scoped tenant and user context from incoming authenticated claims.
/// </summary>
/// <param name="next">The next request delegate in the HTTP pipeline.</param>
public class HeaderMiddleware(RequestDelegate next)
{
    /// <summary>
    /// Processes an incoming HTTP request, extracting TenantId and UserId claims into the scoped request context.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="requestContext">The scoped request context.</param>
    /// <returns>A task representing the completion of request processing.</returns>
    public async Task InvokeAsync(HttpContext context, IRequestContext  requestContext)
    {
        if (context?.User?.Identity?.IsAuthenticated ?? false)
        {
            ArgumentNullException.ThrowIfNull(requestContext);

            var tenantClaim = context.User.Claims.FirstOrDefault(e => e.Type == nameof(ClaimType.TenantId) || e.Type == "TENANT_ID");
            var tenantId = tenantClaim != null ? new Guid(tenantClaim.Value) : Guid.Empty;

            if (tenantId != Guid.Empty)
            {
                requestContext.TenantId = tenantId;
                var userClaim = context.User.Claims.FirstOrDefault(e => e.Type == nameof(ClaimType.UserId) || e.Type == "USER_ID");
                if (userClaim != null)
                {
                    requestContext.UserId = new Guid(userClaim.Value);
                }
            }

            context.Items["TenantId"] = tenantId; // tenantProvider.GetTenantId();
        }

        await next(context!);
    }
}
