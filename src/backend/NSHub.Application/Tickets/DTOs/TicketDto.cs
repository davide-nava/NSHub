// <copyright file="TicketDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.DTOs;

/// <summary>
/// Data transfer object for a ticket comment.
/// </summary>
/// <param name="Id">The unique identifier of the comment.</param>
/// <param name="AuthorId">The author's user identifier.</param>
/// <param name="Message">The comment text message.</param>
/// <param name="CreatedAtUtc">The comment creation timestamp in UTC.</param>
/// <param name="IsInternalOnly">A value indicating whether the comment is internal-only.</param>
public sealed record TicketCommentDto(
    Guid Id,
    Guid AuthorId,
    string Message,
    DateTime CreatedAtUtc,
    bool IsInternalOnly);

/// <summary>
/// Data transfer object for a support ticket.
/// </summary>
/// <param name="Id">The unique identifier of the ticket.</param>
/// <param name="Title">The ticket title.</param>
/// <param name="Description">The ticket description.</param>
/// <param name="RequesterId">The user identifier who submitted the ticket.</param>
/// <param name="AssignedTechnicianId">The user identifier of the assigned technician.</param>
/// <param name="Priority">The ticket priority string.</param>
/// <param name="Status">The ticket status string.</param>
/// <param name="ResolutionDeadlineUtc">The resolution deadline under SLA in UTC.</param>
/// <param name="IsSlaBreached">A value indicating whether SLA deadline has been breached.</param>
/// <param name="ResolutionNotes">The resolution notes, if resolved.</param>
/// <param name="ResolvedAtUtc">The timestamp when resolved in UTC.</param>
/// <param name="ClosedAtUtc">The timestamp when closed in UTC.</param>
/// <param name="CreatedAtUtc">The timestamp when created in UTC.</param>
/// <param name="Comments">The collection of ticket comments.</param>
public sealed record TicketDto(
    Guid Id,
    string Title,
    string Description,
    Guid RequesterId,
    Guid? AssignedTechnicianId,
    string Priority,
    string Status,
    DateTime ResolutionDeadlineUtc,
    bool IsSlaBreached,
    string? ResolutionNotes,
    DateTime? ResolvedAtUtc,
    DateTime? ClosedAtUtc,
    DateTime CreatedAtUtc,
    IReadOnlyList<TicketCommentDto> Comments);
