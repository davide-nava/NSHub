// <copyright file="TicketStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Tickets.Enums;

/// <summary>
/// Lifecycle statuses for support tickets.
/// </summary>
public enum TicketStatus
{
    /// <summary>
    /// Initial status upon creation awaiting triage or assignment.
    /// </summary>
    OPEN = 1,

    /// <summary>
    /// Assigned to an agent and undergoing active investigation or remediation.
    /// </summary>
    IN_PROGRESS = 2,

    /// <summary>
    /// Resolution applied by support agent awaiting stakeholder confirmation.
    /// </summary>
    RESOLVED = 3,

    /// <summary>
    /// Final closed state. Closed tickets are strictly immutable.
    /// </summary>
    CLOSED = 4
}
