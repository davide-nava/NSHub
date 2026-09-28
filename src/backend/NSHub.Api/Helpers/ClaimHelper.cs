// <copyright file="ClaimHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

namespace NSHub.Api.Helpers;

/// <summary>
/// Helper class for managing Identity claims on ClaimsPrincipal.
/// </summary>
public class ClaimHelper(UserManager<IdentityUser> userManager)
{
    /// <summary>
    /// Adds missing claims to the specified principal.
    /// </summary>
    /// <param name="principal">The principal to update.</param>
    /// <param name="aspUser">The ASP.NET Identity user.</param>
    /// <param name="tenantId">The optional tenant identifier.</param>
    /// <returns>The updated claims principal.</returns>
    public async Task<ClaimsPrincipal> AddMissingClaimsAsync(ClaimsPrincipal principal, IdentityUser aspUser, Guid? tenantId)
    {
        ArgumentNullException.ThrowIfNull(principal);
        ArgumentNullException.ThrowIfNull(aspUser);

        var claimList = (await userManager.GetClaimsAsync(aspUser)).Select(p => p.Type).ToList();

        if (tenantId.HasValue && !claimList.Contains(nameof(ClaimType.TenantId)))
        {
            principal = await AddClaimsAsync(principal, aspUser, nameof(ClaimType.TenantId), tenantId.Value.ToString());
        }

        if (!claimList.Contains(nameof(ClaimType.UserId)))
        {
            principal = await AddClaimsAsync(principal, aspUser, nameof(ClaimType.UserId), aspUser.Id);
        }

        if (!string.IsNullOrWhiteSpace(aspUser.Email) && !claimList.Contains(ClaimTypes.NameIdentifier))
        {
            principal = await AddClaimsAsync(principal, aspUser, ClaimTypes.NameIdentifier, aspUser.Email);
        }

        return principal;
    }

    private async Task<ClaimsPrincipal> AddClaimsAsync(ClaimsPrincipal principal, IdentityUser aspUser, string name, string value)
    {
        _ = await userManager.AddClaimAsync(aspUser, new Claim(name, value));

        ClaimsIdentity claId = new();
        claId.AddClaim(new Claim(name, value));
        principal.AddIdentity(claId);

        return principal;
    }
}
