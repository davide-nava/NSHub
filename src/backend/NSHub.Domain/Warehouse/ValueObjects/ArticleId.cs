// <copyright file="ArticleId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Strongly-typed identifier for an inventory article or product.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct ArticleId(Guid Value)
{
    /// <summary>
    /// Initializes an empty article identifier.
    /// </summary>
    public static ArticleId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique article identifier.
    /// </summary>
    public static ArticleId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(ArticleId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator ArticleId(Guid value) => new(value);
}
