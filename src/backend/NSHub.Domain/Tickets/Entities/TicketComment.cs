// <copyright file="TicketComment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Tickets.Entities;

using NSHub.Domain.Common;
using NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Domain entity representing a discussion entry or internal note on a ticket.
/// </summary>
public class TicketComment : Entity<TicketCommentId>
{
    /// <summary>
    /// Gets the parent ticket identifier.
    /// </summary>
    public TicketId TicketId { get; private set; }

    /// <summary>
    /// Gets the identifier of the author who created the comment.
    /// </summary>
    public Guid AuthorId { get; private set; }

    /// <summary>
    /// Gets the message content.
    /// </summary>
    public string Message { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the UTC creation timestamp.
    /// </summary>
    public DateTime CreatedAtUtc { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the comment is internal-only (staff-facing).
    /// </summary>
    public bool IsInternalOnly { get; private set; }

    // Parameterless constructor for EF Core
    private TicketComment()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TicketComment"/> class.
    /// </summary>
    public TicketComment(
        TicketCommentId id,
        TicketId ticketId,
        Guid authorId,
        string message,
        bool isInternalOnly = false)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Comment message cannot be empty.", nameof(message));
        }

        Id = id.Value == Guid.Empty ? TicketCommentId.New() : id;
        TicketId = ticketId;
        AuthorId = authorId;
        Message = message.Trim();
        CreatedAtUtc = DateTime.UtcNow;
        IsInternalOnly = isInternalOnly;
    }
}
