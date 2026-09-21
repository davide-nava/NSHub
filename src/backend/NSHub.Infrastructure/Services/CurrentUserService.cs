// <copyright file="CurrentUserService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NSHub.Application.Common.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Provides access to the currently authenticated user's claims from the HTTP context.
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
        }
    }

    /// <inheritdoc/>
    public string? Email =>
        httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

    /// <inheritdoc/>
    public string? Role =>
        httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

    /// <inheritdoc/>
    public string PreferredLanguage =>
        httpContextAccessor.HttpContext?.User?.FindFirst("lang")?.Value ?? "it";
}
