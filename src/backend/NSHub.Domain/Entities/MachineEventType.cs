// <copyright file="MachineEventType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineEventType : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<MachineEvent> _machineEvents = new();
    public virtual IReadOnlyCollection<MachineEvent> MachineEvents => _machineEvents.AsReadOnly();

    protected MachineEventType() { }

    public static MachineEventType Create()
    {
        return new MachineEventType();
    }
}
