// <copyright file="MachineAxisEncoder.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineAxisEncoder : AuditableTenantEntity
{
    public string Axis { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineAxisEncoder() { }

    public static MachineAxisEncoder Create()
    {
        return new MachineAxisEncoder();
    }
}
