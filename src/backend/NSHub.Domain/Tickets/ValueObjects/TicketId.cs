// <copyright file="TicketId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a support ticket.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct TicketId(Guid Value)
{
    /// <summary>
    /// Initializes an empty ticket identifier.
    /// </summary>
    public static TicketId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique ticket identifier.
    /// </summary>
    public static TicketId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(TicketId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator TicketId(Guid value) => new(value);
}
