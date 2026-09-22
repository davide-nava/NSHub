// <copyright file="Ticket.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;
using NSHub.Domain.Exceptions;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing a service desk ticket, its SLA deadlines, and comment trail.
/// </summary>
public class Ticket : BaseEntity
{

    /// <summary>
    /// Gets the ticket title or summary.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the detailed description of the issue or request.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the identifier of the user or employee requesting assistance.
    /// </summary>
    public Guid RequesterId { get; set; }

    /// <summary>
    /// Gets the assigned technician identifier, if assigned.
    /// </summary>
    public Guid? AssignedTechnicianId { get; set; }

    /// <summary>
    /// Gets the priority level of the ticket.
    /// </summary>
    public TicketPriority Priority { get; set; }

    /// <summary>
    /// Gets the current lifecycle status.
    /// </summary>
    public TicketStatus Status { get; set; }

    /// <summary>
    /// Gets the SLA target and resolution deadline.
    /// </summary>
    public SlaTarget Sla { get; set; } = null!;

    /// <summary>
    /// Gets the resolution notes provided by the technician upon resolution.
    /// </summary>
    public string? ResolutionNotes { get; set; }

    /// <summary>
    /// Gets the UTC timestamp when the ticket was resolved.
    /// </summary>
    public DateTime? ResolvedAtUtc { get; set; }

    /// <summary>
    /// Gets the UTC timestamp when the ticket was closed.
    /// </summary>
    public DateTime? ClosedAtUtc { get; set; }

    /// <summary>
    /// Gets the UTC timestamp when the ticket was created.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Gets the chronological discussion and audit comments.
    /// </summary>
    public IReadOnlyCollection<TicketComment> Comments => _comments.AsReadOnly();
}
