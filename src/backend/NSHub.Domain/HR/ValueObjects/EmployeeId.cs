// <copyright file="EmployeeId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.HR.ValueObjects;

/// <summary>
/// Strongly-typed identifier for an employee aggregate.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct EmployeeId(Guid Value)
{
    /// <summary>
    /// Initializes an empty employee identifier.
    /// </summary>
    public static EmployeeId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique employee identifier.
    /// </summary>
    public static EmployeeId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(EmployeeId id) => id.Value;

    /// <summary>
    /// Explicit conversion from Guid.
    /// </summary>
    public static explicit operator EmployeeId(Guid value) => new(value);
}
