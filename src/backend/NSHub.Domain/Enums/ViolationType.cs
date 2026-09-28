// <copyright file="ViolationType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Flags indicating statutory labor law violations under Swiss labor regulation.
/// </summary>
[Flags]
public enum ViolationType
{
    /// <summary>
    /// No violation.
    /// </summary>
    None = 0,

    /// <summary>
    /// Mandatory daily rest period was not observed.
    /// </summary>
    RestPeriod = 1,

    /// <summary>
    /// Statutory maximum daily amplitude was exceeded.
    /// </summary>
    DailyAmplitude = 2,

    /// <summary>
    /// Statutory weekly limit was exceeded.
    /// </summary>
    WeeklyLimit = 4,
}
