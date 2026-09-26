// <copyright file="Nation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Nation : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string? Name { get; protected set; }

    private readonly List<Address> _addresses = new();
    public virtual IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    protected Nation() { }

    public static Nation Create()
    {
        return new Nation();
    }
}
