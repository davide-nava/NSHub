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
    /// Gets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; protected set; }

    /// <summary>
    /// Gets the machine identifier.
    /// </summary>
    public Guid MachineId { get; protected set; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// Gets the ticket status type identifier.
    /// </summary>
    public Guid TicketStatusTypeId { get; protected set; }

    /// <summary>
    /// Gets the status change date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the status notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; protected set; }

    /// <summary>
    /// Gets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; protected set; }

    /// <summary>
    /// Gets the ticket status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual TicketStatusType? TicketStatusType { get; protected set; }

    /// <summary>
    /// Gets the user who performed the status change.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; protected set; }
}
