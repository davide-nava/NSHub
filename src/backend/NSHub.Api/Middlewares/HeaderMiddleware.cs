// <copyright file="HeaderMiddleware.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Interfaces;
using NSHub.Domain.Enums;

namespace NSHub.Api.Middlewares;

public class HeaderMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IRequestContext  requestContext)
    {
        if (context?.User?.Identity?.IsAuthenticated ?? false)
        {
            ArgumentNullException.ThrowIfNull(requestContext);

            var tenantId = new Guid(context.User.Claims.First(e => e.Type == nameof(ClaimType.TENANT_ID)).Value);

            if (tenantId != Guid.Empty)
            {
                requestContext.TenantId = tenantId;
                requestContext.UserId = new Guid(context.User.Claims.First(e => e.Type == nameof(ClaimType.USER_ID)).Value);
            }

            context.Items["TenantId"] = tenantId; // tenantProvider.GetTenantId();
        }

        await next(context!);
    }
}
