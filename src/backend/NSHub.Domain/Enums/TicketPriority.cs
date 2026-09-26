// <copyright file="TicketPriority.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Urgency and business impact priority levels for support tickets.
/// </summary>
public enum TicketPriority
{
    /// <summary>
    /// Low priority (e.g., minor inquiries, non-blocking requests). SLA: 72 hours.
    /// </summary>
    Low = 1,

    /// <summary>
    /// Standard priority (e.g., standard workflow issues). SLA: 24 hours.
    /// </summary>
    Medium = 2,

    /// <summary>
    /// High priority (e.g., degraded service, blocked user workflow). SLA: 8 hours.
    /// </summary>
    High = 3,

    /// <summary>
    /// Critical priority (e.g., total system outage, security incident). SLA: 4 hours.
    /// </summary>
    Critical = 4,
}
