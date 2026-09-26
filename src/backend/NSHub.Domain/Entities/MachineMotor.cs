// <copyright file="MachineMotor.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineMotor : AuditableTenantEntity
{
    public string Axis { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineMotor() { }

    public static MachineMotor Create()
    {
        return new MachineMotor();
    }
}
