// <copyright file="TicketComment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a comment associated with a ticket.
/// </summary>
public class TicketComment : AuditableTenantEntity
{
    /// <summary>
    /// Gets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; protected set; }

    /// <summary>
    /// Gets the comment description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the comment date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the author user identifier.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// Gets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; protected set; }

    /// <summary>
    /// Gets the user who created the comment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; protected set; }
}
