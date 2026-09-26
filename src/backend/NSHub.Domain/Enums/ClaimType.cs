// <copyright file="ClaimType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Security claim types used throughout user authentication and authorization.
/// </summary>
public enum ClaimType
{
    /// <summary>
    /// Tenant identifier claim.
    /// </summary>
    TenantId = 0,

    /// <summary>
    /// User identifier claim.
    /// </summary>
    UserId = 1,

    /// <summary>
    /// Active state flag claim.
    /// </summary>
    IsActive = 2,

    /// <summary>
    /// System hub administrator claim.
    /// </summary>
    IsNsHub = 3,
}
