// <copyright file="TicketStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Enums;

/// <summary>
/// Lifecycle statuses for support tickets.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TicketStatus
{
    /// <summary>
    /// Initial status upon creation awaiting triage or assignment.
    /// </summary>
    Open = 1,

    /// <summary>
    /// Assigned to an agent and undergoing active investigation or remediation.
    /// </summary>
    InProgress = 2,

    /// <summary>
    /// Resolution applied by support agent awaiting stakeholder confirmation.
    /// </summary>
    Resolved = 3,

    /// <summary>
    /// Final closed state. Closed tickets are strictly immutable.
    /// </summary>
    Closed = 4,
}
