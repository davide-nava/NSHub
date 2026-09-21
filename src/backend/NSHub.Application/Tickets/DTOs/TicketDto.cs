// <copyright file="TicketDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.DTOs;

/// <summary>
/// Data transfer object for a ticket comment.
/// </summary>
public sealed record TicketCommentDto(
    Guid Id,
    Guid AuthorId,
    string Message,
    DateTime CreatedAtUtc,
    bool IsInternalOnly);

/// <summary>
/// Data transfer object for a support ticket.
/// </summary>
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
