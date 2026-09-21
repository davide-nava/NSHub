// <copyright file="TimeEntryId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.TimeAttendance.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a time entry aggregate.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct TimeEntryId(Guid Value)
{
    /// <summary>
    /// Initializes an empty time entry identifier.
    /// </summary>
    public static TimeEntryId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique time entry identifier.
    /// </summary>
    public static TimeEntryId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(TimeEntryId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator TimeEntryId(Guid value) => new(value);
}
