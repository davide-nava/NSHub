// <copyright file="CorrectTimeEntryCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;

/// <summary>
/// Command for retroactive manual correction of a time entry with legally mandatory justification (Art. 73 OLL 1).
/// </summary>
public record CorrectTimeEntryCommand(
    Guid TimeEntryId,
    Guid OperatorId,
    DateTime NewClockInUtc,
    DateTime? NewClockOutUtc,
    int NewBreakMinutes,
    string MandatoryReason
) : IRequest<Result<TimeEntryDto>>;
