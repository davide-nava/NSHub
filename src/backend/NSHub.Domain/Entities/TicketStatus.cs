// <copyright file="TicketStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a status change for a ticket.
/// </summary>
public class TicketStatus : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid MachineId { get; set; }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the ticket status type identifier.
    /// </summary>
    public Guid TicketStatusTypeId { get; set; }

    /// <summary>
    /// Gets or sets the status change date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the status notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }

    /// <summary>
    /// Gets or sets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; set; }

    /// <summary>
    /// Gets or sets the ticket status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual TicketStatusType? TicketStatusType { get; set; }

    /// <summary>
    /// Gets or sets the user who performed the status change.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; set; }
}
