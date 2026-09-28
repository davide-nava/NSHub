// <copyright file="TimeEntryStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Status of a time entry.
/// </summary>
public enum TimeEntryStatus
{
    /// <summary>
    /// Open active shift.
    /// </summary>
    Open = 1,

    /// <summary>
    /// Closed completed shift.
    /// </summary>
    Closed = 2,

    /// <summary>
    /// Retroactively corrected shift.
    /// </summary>
    Corrected = 3,
}
