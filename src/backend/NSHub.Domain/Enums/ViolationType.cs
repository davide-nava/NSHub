// <copyright file="ViolationType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Labor law statutory violation flags according to Swiss Labor Law (LL/OLL).
/// </summary>
[Flags]

public enum ViolationType
{
    /// <summary>
    /// No violations detected.
    /// </summary>
    None = 0,

    /// <summary>
    /// Less than 11 hours consecutive rest period violated (Art. 15a LL).
    /// </summary>
    DailyRestPeriodViolated = 1,

    /// <summary>
    /// Daily amplitude exceeded maximum 14 hours (Art. 10 LL).
    /// </summary>
    DailyAmplitudeExceeded = 2,

    /// <summary>
    /// Mandatory rest break not observed (Art. 15 LL).
    /// </summary>
    InsufficientBreak = 4,

    /// <summary>
    /// Statutory maximum weekly working hours exceeded (Art. 12 LL).
    /// </summary>
    StatutoryOvertime = 8,
}
