// <copyright file="TagId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a CMS tag.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct TagId(Guid Value)
{
    /// <summary>
    /// Initializes an empty tag identifier.
    /// </summary>
    public static TagId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique tag identifier.
    /// </summary>
    public static TagId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(TagId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator TagId(Guid value) => new(value);
}
