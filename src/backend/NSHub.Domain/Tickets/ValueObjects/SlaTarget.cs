// <copyright file="SlaTarget.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Service Level Agreement (SLA) target definition and resolution deadline.
/// </summary>
/// <param name="ResolutionDeadlineUtc">The absolute deadline for resolving the ticket in UTC.</param>
/// <param name="MaximumResolutionTime">The total SLA allocated time duration.</param>
public sealed record SlaTarget(DateTime ResolutionDeadlineUtc, TimeSpan MaximumResolutionTime)
{
    /// <summary>
    /// Checks whether the SLA target has been breached given a reference timestamp.
    /// </summary>
    /// <param name="currentTimeUtc">The reference UTC timestamp.</param>
    /// <returns>True if the current time exceeds the deadline; otherwise false.</returns>
    public bool IsBreached(DateTime currentTimeUtc) => currentTimeUtc > ResolutionDeadlineUtc;
}
