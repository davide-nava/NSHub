// <copyright file="UserClaim.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Identity.ValueObjects;

namespace NSHub.Domain.Identity.Entities;

/// <summary>
/// Fine-grained claim assertion attached to a user identity.
/// </summary>
public class UserClaim
{
    /// <summary>
    /// Gets the unique claim identifier.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public UserId UserId { get; private set; }

    /// <summary>
    /// Gets the claim type.
    /// </summary>
    public string Type { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the claim value.
    /// </summary>
    public string Value { get; private set; } = string.Empty;

    // Parameterless constructor for EF Core
    private UserClaim()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserClaim"/> class.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="type">The claim type.</param>
    /// <param name="value">The claim value.</param>
    public UserClaim(UserId userId, string type, string value)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Type = string.IsNullOrWhiteSpace(type) ? throw new ArgumentException("Claim type is required.", nameof(type)) : type.Trim();
        Value = value?.Trim() ?? string.Empty;
    }
}
