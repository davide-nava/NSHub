// <copyright file="TicketCommentId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a ticket comment.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct TicketCommentId(Guid Value)
{
    /// <summary>
    /// Initializes an empty ticket comment identifier.
    /// </summary>
    public static TicketCommentId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique ticket comment identifier.
    /// </summary>
    public static TicketCommentId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(TicketCommentId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator TicketCommentId(Guid value) => new(value);
}
