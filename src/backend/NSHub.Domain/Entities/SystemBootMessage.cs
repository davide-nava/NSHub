// <copyright file="SystemBootMessage.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class SystemBootMessage : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    protected SystemBootMessage() { }

    public static SystemBootMessage Create()
    {
        return new SystemBootMessage();
    }
}
