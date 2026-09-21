// <copyright file="UserStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Identity.Enums;

/// <summary>
/// Lifecycle and security statuses for enterprise users.
/// </summary>
public enum UserStatus
{
    /// <summary>
    /// User is active and authorized to log in.
    /// </summary>
    ACTIVE = 1,

    /// <summary>
    /// User account has been administratively suspended.
    /// </summary>
    SUSPENDED = 2,

    /// <summary>
    /// User is locked out due to exceeding maximum consecutive failed authentication attempts.
    /// </summary>
    LOCKED_OUT = 3,

    /// <summary>
    /// User account is pending email confirmation or administrative verification.
    /// </summary>
    PENDING_VERIFICATION = 4,
}
