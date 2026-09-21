// <copyright file="RoleId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a security role.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct RoleId(Guid Value)
{
    /// <summary>
    /// Initializes an empty role identifier.
    /// </summary>
    public static RoleId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique role identifier.
    /// </summary>
    public static RoleId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(RoleId id) => id.Value;

    /// <summary>
    /// Explicit conversion from Guid.
    /// </summary>
    public static explicit operator RoleId(Guid value) => new(value);
}
