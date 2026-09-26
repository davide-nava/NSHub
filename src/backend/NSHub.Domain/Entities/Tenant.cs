// <copyright file="Tenant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Tenant : AuditableEntity
{
    public string Description { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public bool IsActive { get; protected set; }

    private readonly List<User> _users = new();
    public virtual IReadOnlyCollection<User> Users => _users.AsReadOnly();

    protected Tenant() { }

    public static Tenant Create()
    {
        return new Tenant();
    }
}
