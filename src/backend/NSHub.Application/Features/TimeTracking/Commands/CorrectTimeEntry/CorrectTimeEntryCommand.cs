// <copyright file="CorrectTimeEntryCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using MediatR;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;

namespace NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;

/// <summary>
/// Command for retroactive manual correction of a time entry with legally mandatory justification.
/// </summary>
/// <param name="TimeEntryId">The unique identifier of the time entry being corrected.</param>
/// <param name="OperatorId">The unique identifier of the operator applying the correction.</param>
/// <param name="NewClockInUtc">The corrected clock-in time in UTC.</param>
/// <param name="NewClockOutUtc">The corrected clock-out time in UTC, if any.</param>
/// <param name="NewBreakMinutes">The corrected break duration in minutes.</param>
/// <param name="MandatoryReason">The legally required audit rationale for the change.</param>
public record CorrectTimeEntryCommand(
    Guid TimeEntryId,
    Guid OperatorId,
    DateTime NewClockInUtc,
    DateTime? NewClockOutUtc,
    int NewBreakMinutes,
    string MandatoryReason
) : IRequest<Result<TimeEntryDto>>;
