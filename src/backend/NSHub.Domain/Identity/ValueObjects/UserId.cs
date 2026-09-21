// <copyright file="UserId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Strongly-typed identifier for an enterprise user.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct UserId(Guid Value)
{
    /// <summary>
    /// Initializes an empty user identifier.
    /// </summary>
    public static UserId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique user identifier.
    /// </summary>
    public static UserId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(UserId id) => id.Value;

    /// <summary>
    /// Explicit conversion from Guid.
    /// </summary>
    public static explicit operator UserId(Guid value) => new(value);
}
