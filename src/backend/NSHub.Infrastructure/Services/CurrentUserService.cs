// <copyright file="CurrentUserService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NSHub.Application.Common.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Service providing claims-based identity details for the currently authenticated user.
/// </summary>
public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    /// <inheritdoc/>
    public Guid? UserId
    {
        get
        {
            var idClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? httpContextAccessor.HttpContext?.User.FindFirst("sub")?.Value;

            return Guid.TryParse(idClaim, out var id) ? id : null;
        }
    }

    /// <inheritdoc/>
    public Guid? TenantId
    {
        get
        {
            var tenantClaim = httpContextAccessor.HttpContext?.User.FindFirst("tenant_id")?.Value
                ?? httpContextAccessor.HttpContext?.User.FindFirst("TenantId")?.Value;

            return Guid.TryParse(tenantClaim, out var id) ? id : null;
        }
    }

    /// <inheritdoc/>
    public bool IsAuthenticated => httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

    /// <inheritdoc/>
    public string? Email => httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value
        ?? httpContextAccessor.HttpContext?.User.FindFirst("email")?.Value;

    /// <inheritdoc/>
    public string? Role => httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value
        ?? httpContextAccessor.HttpContext?.User.FindFirst("role")?.Value;

    /// <inheritdoc/>
    public string PreferredLanguage => httpContextAccessor.HttpContext?.User.FindFirst("lang")?.Value ?? "it";
}
