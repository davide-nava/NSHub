// <copyright file="HttpTenantProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace NSHub.Infrastructure.Providers;

public class HttpTenantProvider(IHttpContextAccessor httpContextAccessor) : ITenantProvider
{
    public Guid GetTenantId()
    {
        var context = httpContextAccessor.HttpContext;
        return new Guid(context?.Request.Headers["X-TenantId"].FirstOrDefault() ?? Guid.Empty.ToString());
    }
}
