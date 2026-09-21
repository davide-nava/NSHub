// <copyright file="Ticket.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Tickets.Entities;

using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Tickets.Enums;
using NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Aggregate root representing a service desk ticket, its SLA deadlines, and comment trail.
/// </summary>
public class Ticket : AggregateRoot<TicketId>
{
    private readonly List<TicketComment> _comments = [];

    /// <summary>
    /// Gets the ticket title or summary.
    /// </summary>
    public string Title { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the detailed description of the issue or request.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the identifier of the user or employee requesting assistance.
    /// </summary>
    public Guid RequesterId { get; private set; }

    /// <summary>
    /// Gets the assigned technician identifier, if assigned.
    /// </summary>
    public Guid? AssignedTechnicianId { get; private set; }

    /// <summary>
    /// Gets the priority level of the ticket.
    /// </summary>
    public TicketPriority Priority { get; private set; }

    /// <summary>
    /// Gets the current lifecycle status.
    /// </summary>
    public TicketStatus Status { get; private set; }

    /// <summary>
    /// Gets the SLA target and resolution deadline.
    /// </summary>
    public SlaTarget Sla { get; private set; } = null!;

    /// <summary>
    /// Gets the resolution notes provided by the technician upon resolution.
    /// </summary>
    public string? ResolutionNotes { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the ticket was resolved.
    /// </summary>
    public DateTime? ResolvedAtUtc { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the ticket was closed.
    /// </summary>
    public DateTime? ClosedAtUtc { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the ticket was created.
    /// </summary>
    public DateTime CreatedAtUtc { get; private set; }

    /// <summary>
    /// Gets the chronological discussion and audit comments.
    /// </summary>
    public IReadOnlyCollection<TicketComment> Comments => _comments.AsReadOnly();

    // Parameterless constructor for EF Core
    private Ticket()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Ticket"/> aggregate root.
    /// </summary>
    public Ticket(
        TicketId id,
        string title,
        string description,
        Guid requesterId,
        TicketPriority priority)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new BusinessRuleValidationException("Ticket.TitleRequired", "Ticket title is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new BusinessRuleValidationException("Ticket.DescriptionRequired", "Ticket description is mandatory.");
        }

        if (requesterId == Guid.Empty)
        {
            throw new BusinessRuleValidationException("Ticket.RequesterRequired", "Requester identifier is mandatory.");
        }

        Id = id.Value == Guid.Empty ? TicketId.New() : id;
        Title = title.Trim();
        Description = description.Trim();
        RequesterId = requesterId;
        Priority = priority;
        Status = TicketStatus.OPEN;
        CreatedAtUtc = DateTime.UtcNow;
        Sla = CalculateSlaTarget(CreatedAtUtc, priority);
    }

    /// <summary>
    /// Assigns a support technician to the ticket.
    /// </summary>
    /// <param name="technicianId">The technician's identifier.</param>
    public void AssignTechnician(Guid technicianId)
    {
        EnsureNotClosed();

        if (technicianId == Guid.Empty)
        {
            throw new BusinessRuleValidationException("Ticket.InvalidTechnician", "Technician identifier cannot be empty.");
        }

        AssignedTechnicianId = technicianId;
        if (Status == TicketStatus.OPEN)
        {
            Status = TicketStatus.IN_PROGRESS;
        }
    }

    /// <summary>
    /// Marks the ticket as in progress.
    /// </summary>
    public void StartProgress()
    {
        EnsureNotClosed();

        if (Status == TicketStatus.OPEN)
        {
            Status = TicketStatus.IN_PROGRESS;
        }
    }

    /// <summary>
    /// Resolves the ticket with technician notes.
    /// </summary>
    /// <param name="resolutionNotes">Detailed description of how the issue was resolved.</param>
    public void Resolve(string resolutionNotes)
    {
        EnsureNotClosed();

        if (string.IsNullOrWhiteSpace(resolutionNotes))
        {
            throw new BusinessRuleValidationException("Ticket.ResolutionNotesRequired", "Resolution notes are required when resolving a ticket.");
        }

        ResolutionNotes = resolutionNotes.Trim();
        ResolvedAtUtc = DateTime.UtcNow;
        Status = TicketStatus.RESOLVED;
    }

    /// <summary>
    /// Closes the ticket permanently. Once closed, the ticket becomes completely immutable.
    /// </summary>
    public void Close()
    {
        if (Status == TicketStatus.CLOSED)
        {
            return;
        }

        if (Status != TicketStatus.RESOLVED)
        {
            throw new InvalidStateTransitionException(
                Status.ToString(),
                TicketStatus.CLOSED.ToString(),
                "Ticket must be resolved before closing.");
        }

        Status = TicketStatus.CLOSED;
        ClosedAtUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Reopens a resolved ticket back to in-progress status.
    /// </summary>
    public void Reopen()
    {
        EnsureNotClosed();

        if (Status == TicketStatus.RESOLVED)
        {
            Status = TicketStatus.IN_PROGRESS;
            ResolvedAtUtc = null;
            ResolutionNotes = null;
        }
    }

    /// <summary>
    /// Appends a new discussion comment or internal note to the ticket.
    /// </summary>
    public TicketComment AddComment(Guid authorId, string message, bool isInternalOnly = false)
    {
        EnsureNotClosed();

        var comment = new TicketComment(TicketCommentId.New(), Id, authorId, message, isInternalOnly);
        _comments.Add(comment);
        return comment;
    }

    /// <summary>
    /// Updates the priority level and recalculates SLA deadline.
    /// </summary>
    public void UpdatePriority(TicketPriority priority)
    {
        EnsureNotClosed();

        Priority = priority;
        Sla = CalculateSlaTarget(CreatedAtUtc, priority);
    }

    private void EnsureNotClosed()
    {
        if (Status == TicketStatus.CLOSED)
        {
            throw new TicketClosedException(Id.Value);
        }
    }

    private static SlaTarget CalculateSlaTarget(DateTime createdAtUtc, TicketPriority priority)
    {
        var duration = priority switch
        {
            TicketPriority.CRITICAL => TimeSpan.FromHours(4),
            TicketPriority.HIGH => TimeSpan.FromHours(8),
            TicketPriority.MEDIUM => TimeSpan.FromHours(24),
            TicketPriority.LOW => TimeSpan.FromHours(72),
            _ => TimeSpan.FromHours(24)
        };

        return new SlaTarget(createdAtUtc.Add(duration), duration);
    }
}
