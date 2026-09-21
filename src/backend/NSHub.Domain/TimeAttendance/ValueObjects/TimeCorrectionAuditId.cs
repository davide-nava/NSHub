// <copyright file="TimeCorrectionAuditId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.TimeAttendance.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a time correction audit record.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct TimeCorrectionAuditId(Guid Value)
{
    /// <summary>
    /// Initializes an empty time correction audit identifier.
    /// </summary>
    public static TimeCorrectionAuditId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique time correction audit identifier.
    /// </summary>
    public static TimeCorrectionAuditId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(TimeCorrectionAuditId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator TimeCorrectionAuditId(Guid value) => new(value);
}
