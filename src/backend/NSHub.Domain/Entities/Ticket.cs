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
    /// Gets the user identifier.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; protected set; }

    /// <summary>
    /// Gets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; protected set; }

    /// <summary>
    /// Gets the current ticket status type identifier.
    /// </summary>
    public Guid TicketStatusTypeId { get; protected set; }

    /// <summary>
    /// Gets the ticket title.
    /// </summary>
    public string Title { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the ticket description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the ticket closing date.
    /// </summary>
    public DateTime ClosingDate { get; protected set; }

    /// <summary>
    /// Gets the ticket opening date.
    /// </summary>
    public DateTime OpeningDate { get; protected set; }

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; protected set; }

    /// <summary>
    /// Gets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; protected set; }

    /// <summary>
    /// Gets the current ticket status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual TicketStatusType? TicketStatusType { get; protected set; }

    /// <summary>
    /// Gets the user who opened the ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; protected set; }

    /// <summary>
    /// Gets the comments associated with this ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketComment> TicketComments { get; protected set; }
        = new List<TicketComment>();

    /// <summary>
    /// Gets the status history associated with this ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketStatus> TicketStatuses { get; protected set; }
        = new List<TicketStatus>();
}
