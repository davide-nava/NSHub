// <copyright file="StockLocationId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a warehouse stock location.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct StockLocationId(Guid Value)
{
    /// <summary>
    /// Initializes an empty stock location identifier.
    /// </summary>
    public static StockLocationId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique stock location identifier.
    /// </summary>
    public static StockLocationId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(StockLocationId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator StockLocationId(Guid value) => new(value);
}
