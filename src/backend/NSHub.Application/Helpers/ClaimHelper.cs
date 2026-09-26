// <copyright file="ClaimHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NSHub.Application.Models;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

namespace NSHub.Application.Helpers;

public class ClaimHelper(UserManager<ApplicationUser> userManager)
{
    public async Task<ClaimsPrincipal> AddMissingClaimsAsync(ClaimsPrincipal principal, ApplicationUser aspUser)
    {
        ArgumentNullException.ThrowIfNull(principal);
        ArgumentNullException.ThrowIfNull(aspUser);

        var claimList = (await userManager.GetClaimsAsync(aspUser)).Select(p => p.Type).ToList();

        if (aspUser.TenantId.HasValue && !claimList.Contains(nameof(ClaimType.TenantId)))
        {
            principal = await AddClaimsAsync(principal, aspUser, nameof(ClaimType.TenantId), aspUser.TenantId.Value.ToString());
        }

        if (!claimList.Contains(nameof(ClaimType.UserId)))
        {
            principal = await AddClaimsAsync(principal, aspUser, nameof(ClaimType.UserId), aspUser.Id.ToString());
        }

        if (!string.IsNullOrWhiteSpace(aspUser.Email) && !claimList.Contains(nameof(ClaimTypes.NameIdentifier)))
        {
            principal = await AddClaimsAsync(principal, aspUser, nameof(ClaimTypes.NameIdentifier), aspUser.Email);
        }

        return principal;
    }

    public async Task<Claim?> AddMissingClaimAsync(ApplicationUser aspUser)
    {
        ArgumentNullException.ThrowIfNull(aspUser);

        Claim? claim = null;

        var claimList = (await userManager.GetClaimsAsync(aspUser)).Select(p => p.Type).ToList();

        if (aspUser.TenantId.HasValue && !claimList.Contains(nameof(ClaimType.TenantId)))
        {
            claim = await AddClaimAsync(aspUser, nameof(ClaimType.TenantId), aspUser.TenantId.Value.ToString());
        }

        if (!claimList.Contains(nameof(ClaimType.UserId)))
        {
            claim = await AddClaimAsync(aspUser, nameof(ClaimType.UserId), aspUser.Id.ToString());
        }

        if (!string.IsNullOrWhiteSpace(aspUser.Email) && !claimList.Contains(nameof(ClaimTypes.NameIdentifier)))
        {
            claim = await AddClaimAsync(aspUser, nameof(ClaimTypes.NameIdentifier), aspUser.Email);
        }

        return claim;
    }

    private async Task<ClaimsPrincipal> AddClaimsAsync(ClaimsPrincipal principal, ApplicationUser aspUser, string name, string value)
    {
        _ = await userManager.AddClaimAsync(aspUser, new Claim(name, value));

        ClaimsIdentity claId = new();
        claId.AddClaim(new Claim(name, value));
        principal.AddIdentity(claId);

        return principal;
    }

    private async Task<Claim> AddClaimAsync(ApplicationUser aspUser, string name, string value)
    {
        _ = await userManager.AddClaimAsync(aspUser, new Claim(name, value));

        return new Claim(name, value);
    }
}

