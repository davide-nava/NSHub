// <copyright file="CustomerId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a commercial customer.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct CustomerId(Guid Value)
{
    /// <summary>
    /// Initializes an empty customer identifier.
    /// </summary>
    public static CustomerId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique customer identifier.
    /// </summary>
    public static CustomerId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(CustomerId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator CustomerId(Guid value) => new(value);
}
