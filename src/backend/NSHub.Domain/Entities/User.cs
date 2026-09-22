// <copyright file="User.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing an enterprise user identity, authentication invariants, and roles.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique normalized email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current account status.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated ASP.NET user account.
    /// </summary>
    public string AspNetUserId { get; set; } = string.Empty;
}
