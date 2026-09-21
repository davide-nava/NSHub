// <copyright file="PageId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a CMS page.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct PageId(Guid Value)
{
    /// <summary>
    /// Initializes an empty page identifier.
    /// </summary>
    public static PageId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique page identifier.
    /// </summary>
    public static PageId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(PageId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator PageId(Guid value) => new(value);
}
