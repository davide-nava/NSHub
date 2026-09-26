// <copyright file="PlcVariable.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PlcVariable : AuditableTenantEntity
{
    public Guid PlcVariableTypeId { get; protected set; }
    public Guid PlcVariableGroupTypeId { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public string? IconOn { get; protected set; }
    public string? Image { get; protected set; }
    public string? IconOff { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public DateTime InsertionDate { get; protected set; }
    public string? AccessRights { get; protected set; }
    public bool IsWriting { get; protected set; }
    public string? Notes { get; protected set; }
    public bool IsHistorize { get; protected set; }
    public int Order { get; protected set; }
    public string? MachineNumber { get; protected set; }
    public virtual PlcVariableGroupType? PlcVariableGroupType { get; protected set; }
    public virtual PlcVariableType? PlcVariableType { get; protected set; }

    private readonly List<MachinePlcVariable> _machinePlcVariables = new();
    public virtual IReadOnlyCollection<MachinePlcVariable> MachinePlcVariables => _machinePlcVariables.AsReadOnly();

    protected PlcVariable() { }

    public static PlcVariable Create()
    {
        return new PlcVariable();
    }
}
