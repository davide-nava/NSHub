// <copyright file="UserStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Identity.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Lifecycle and security statuses for enterprise users.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserStatus
{
    /// <summary>
    /// User is active and authorized to log in.
    /// </summary>
    Active = 1,

    /// <summary>
    /// User account has been administratively suspended.
    /// </summary>
    Suspended = 2,

    /// <summary>
    /// User is locked out due to exceeding maximum consecutive failed authentication attempts.
    /// </summary>
    LockedOut = 3,

    /// <summary>
    /// User account is pending email confirmation or administrative verification.
    /// </summary>
    PendingVerification = 4,
}
