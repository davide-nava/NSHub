// <copyright file="SerilogType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Enums;

public enum SerilogType
{
    MachineName = 0,

    Host = 1,

    RequestIp = 2,

    EndpointDisplayName = 3,

    CorrelationId = 4,

    Email = 5,

    Application = 6,

    Method = 7,

    Path = 8,

    TenantId = 9,

    LogTypeId = 10,

    UserId = 11,

    RecordId = 12,

    LogActionTypeId = 13,

    Date = 14,
    OldValue = 15,
    NewValue = 16,
}
