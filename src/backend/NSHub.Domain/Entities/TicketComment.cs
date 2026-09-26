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
    /// Gets or sets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// Gets or sets the comment description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the comment date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the author user identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; set; }

    /// <summary>
    /// Gets or sets the user who created the comment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; set; }
}
