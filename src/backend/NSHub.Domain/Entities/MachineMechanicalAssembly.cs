// <copyright file="MachineMechanicalAssembly.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineMechanicalAssembly : AuditableTenantEntity
{
    public string Ref { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineMechanicalAssembly() { }

    public static MachineMechanicalAssembly Create()
    {
        return new MachineMechanicalAssembly();
    }
}
