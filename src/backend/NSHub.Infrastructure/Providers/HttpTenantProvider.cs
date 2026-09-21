// <copyright file="HttpTenantProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace NSHub.Infrastructure.Providers;

/// <summary>
/// HTTP header-based implementation of <see cref="ITenantProvider"/> that resolves the tenant from the X-TenantId header.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="HttpTenantProvider"/> class.
/// </remarks>
/// <param name="httpContextAccessor">The HTTP context accessor.</param>
public class HttpTenantProvider(IHttpContextAccessor httpContextAccessor) : ITenantProvider
{
    /// <inheritdoc/>
    public Guid GetTenantId()
    {
        var context = httpContextAccessor.HttpContext;
        return new Guid(context?.Request.Headers["X-TenantId"].FirstOrDefault() ?? Guid.Empty.ToString());
    }
}
