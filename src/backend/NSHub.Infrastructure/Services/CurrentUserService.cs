// <copyright file="CurrentUserService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NSHub.Application.Common.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Provides access to the currently authenticated user's claims from the HTTP context.
/// Provides access to the currently authenticated user's claims and tenant information from the HTTP context.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CurrentUserService"/> class.
/// </remarks>
/// <param name="httpContextAccessor">The HTTP context accessor.</param>
public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    /// <inheritdoc/>
    public Guid? UserId
    {
        get
        {
            var claim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(claim, out var id) ? id : null;
            var user = httpContextAccessor.HttpContext?.User;
            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? user?.FindFirst("sub")?.Value
                              ?? user?.FindFirst("uid")?.Value;

            return Guid.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }

    /// <inheritdoc/>
    public Guid? TenantId
    {
        get
        {
            var user = httpContextAccessor.HttpContext?.User;
            var tenantClaim = user?.FindFirst("tenant_id")?.Value
                              ?? httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Id"].ToString();

            return Guid.TryParse(tenantClaim, out var tenantId) ? tenantId : null;
        }
    }

    /// <inheritdoc/>
    public bool IsAuthenticated => httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    /// <inheritdoc/>
    public string? Email =>
        httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

    /// <inheritdoc/>
    public string? Role =>
        httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

    /// <inheritdoc/>
    public string PreferredLanguage =>
        httpContextAccessor.HttpContext?.User?.FindFirst("lang")?.Value ?? "it";


    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)
                              ?? _httpContextAccessor.HttpContext?.User?.FindFirstValue("sub")
                              ?? _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");

            return Guid.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }

    public Guid? TenantId
    {
        get
        {
            var tenantClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue("tenant_id")
                              ?? _httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Id"].ToString();

            return Guid.TryParse(tenantClaim, out var tenantId) ? tenantId : null;
        }
    }

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
}
