// <copyright file="Ticket.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a support ticket.
/// </summary>
public class Ticket : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; set; }

    /// <summary>
    /// Gets or sets the current ticket status type identifier.
    /// </summary>
    public Guid TicketStatusTypeId { get; set; }

    /// <summary>
    /// Gets or sets the ticket title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ticket description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ticket closing date.
    /// </summary>
    public DateTime ClosingDate { get; set; }

    /// <summary>
    /// Gets or sets the ticket opening date.
    /// </summary>
    public DateTime OpeningDate { get; set; }

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }

    /// <summary>
    /// Gets or sets the current ticket status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual TicketStatusType? TicketStatusType { get; set; }

    /// <summary>
    /// Gets or sets the user who opened the ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// Gets or sets the comments associated with this ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketComment> TicketComments { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the status history associated with this ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketStatus> TicketStatuses { get; set; }
        = [];
}
