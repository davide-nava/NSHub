// <copyright file="TimeEntryStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Status of a time entry record.
/// </summary>
public enum TimeEntryStatus
{
    /// <summary>
    /// The shift is actively in progress.
    /// </summary>
    Active = 1,

    /// <summary>
    /// The shift has ended.
    /// </summary>
    Completed = 2,

    /// <summary>
    /// The entry has undergone retroactive correction.
    /// </summary>
    Corrected = 3,
}
