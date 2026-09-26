// <copyright file="MachineScrew.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineScrew : AuditableTenantEntity
{
    public string Axis { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineScrew() { }

    public static MachineScrew Create()
    {
        return new MachineScrew();
    }
}
