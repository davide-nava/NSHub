// <copyright file="SerilogPropertyType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Enums;

/// <summary>
/// Defines the standard property names used to enrich Serilog log entries.
/// </summary>
public enum SerilogPropertyType
{
    /// <summary>
    /// Represents the machine name where the application is running.
    /// </summary>
    MachineName = 0,

    /// <summary>
    /// Represents the host name or server identifier.
    /// </summary>
    Host = 1,

    /// <summary>
    /// Represents the IP address of the incoming request.
    /// </summary>
    RequestIp = 2,

    /// <summary>
    /// Represents the display name of the executed endpoint.
    /// </summary>
    EndpointDisplayName = 3,

    /// <summary>
    /// Represents the correlation identifier used for request tracing.
    /// </summary>
    CorrelationId = 4,

    /// <summary>
    /// Represents the email address associated with the request or user.
    /// </summary>
    Email = 5,

    /// <summary>
    /// Represents the application identifier or application name.
    /// </summary>
    Application = 6,

    /// <summary>
    /// Represents the HTTP method associated with the request.
    /// </summary>
    Method = 7,

    /// <summary>
    /// Represents the request path or route.
    /// </summary>
    Path = 8,

    /// <summary>
    /// Represents the tenant identifier.
    /// </summary>
    TenantId = 9,

    /// <summary>
    /// Represents the log type identifier.
    /// </summary>
    LogTypeId = 10,

    /// <summary>
    /// Represents the user identifier.
    /// </summary>
    UserId = 11,

    /// <summary>
    /// Represents the identifier of the affected record.
    /// </summary>
    RecordId = 12,

    /// <summary>
    /// Represents the log action type identifier.
    /// </summary>
    LogActionTypeId = 13,

    /// <summary>
    /// Represents the date and time associated with the log entry.
    /// </summary>
    Date = 14,

    /// <summary>
    /// Represents the previous value before a change occurred.
    /// </summary>
    OldValue = 15,

    /// <summary>
    /// Represents the new value after a change occurred.
    /// </summary>
    NewValue = 16,
}
