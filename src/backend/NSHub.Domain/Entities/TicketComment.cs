// <copyright file="TicketComment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a discussion entry or internal note on a ticket.
/// </summary>
public class TicketComment : BaseEntity
{
    /// <summary>
    /// Gets the parent ticket identifier.
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// Gets the identifier of the author who created the comment.
    /// </summary>
    public Guid AuthorId { get; set; }

    /// <summary>
    /// Gets the message content.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Gets the UTC creation timestamp.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Gets a value indicating whether the comment is internal-only (staff-facing).
    /// </summary>
    public bool IsInternalOnly { get; set; }
}
