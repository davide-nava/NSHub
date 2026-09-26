using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetRoles : BaseEntity<string>
{
    public string? Name { get; protected set; }
    public string? NormalizedName { get; protected set; }
    public string? ConcurrencyStamp { get; protected set; }

    private readonly List<AspNetRoleClaims> _aspNetRoleClaimses = new();
    public virtual IReadOnlyCollection<AspNetRoleClaims> AspNetRoleClaimses => _aspNetRoleClaimses.AsReadOnly();
    private readonly List<AspNetUserRoles> _aspNetUserRoleses = new();
    public virtual IReadOnlyCollection<AspNetUserRoles> AspNetUserRoleses => _aspNetUserRoleses.AsReadOnly();

    protected AspNetRoles() { }

    public static AspNetRoles Create()
    {
        return new AspNetRoles();
    }
}
