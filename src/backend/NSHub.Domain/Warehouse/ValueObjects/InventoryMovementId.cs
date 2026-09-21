// <copyright file="InventoryMovementId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Strongly-typed identifier for an inventory ledger movement.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct InventoryMovementId(Guid Value)
{
    /// <summary>
    /// Initializes an empty inventory movement identifier.
    /// </summary>
    public static InventoryMovementId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique inventory movement identifier.
    /// </summary>
    public static InventoryMovementId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(InventoryMovementId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator InventoryMovementId(Guid value) => new(value);
}
